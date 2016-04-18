using MediaInfoLib;
using qaacGUI.cmdCodeGenerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qaacGUI.taskManager
{
    class Job
    {
        private runningPool rp;
        public qaacTask[] tasks;
        public int num;
        public int finishedNum;
        public int threadsNum;
        private bool[] isfinished;
        private cmdCode commonCode;

        private RunningStatusForm rsForm;
        private int[] PIDs;

        //private Process process = null;

        public Job(filePathStorage tempQueue)
        {
            // 从storage读取num
            this.num = tempQueue.Count();
            this.threadsNum = 1;

            this.finishedNum = 0;

            //MessageBox.Show("Get: " + this.num);
            
            // 初始化task数组来feed下面的queue
            this.tasks = new qaacTask[num];
            this.PIDs = new int[threadsNum];
            this.isfinished = new bool[threadsNum];
            this.commonCode = tempQueue.c;
            for (int i = 0; i < num; i++ )
            {
                // 从临时队列读取文件路径
                string path = tempQueue.get(i);

                this.tasks[i] = new qaacTask(path);          

                //MessageBox.Show("Get: " + this.tasks[i].filePath);
            }

            // 初始化运行池pool
            this.rp = new runningPool(this.num, this.tasks);  // 运行池持有队列，需传递队列的相关参数

            // 初始化运行状态窗口
            this.rsForm  = new RunningStatusForm();
 
        }
        
        public void runJob()
        {
            this.rsForm.Show();

            Thread[] threads = new Thread[this.threadsNum];
            for (int i = 0; i < threadsNum; i++)
            {
                int p = i;
                Thread th = new Thread(()=>
                {
                    this.isfinished[p] = true;
                    this.threadRun(p);
                });
                threads[p] = th;
            }
            for (int i = 0; i < threadsNum; i++)
            {
                threads[i].Start();
            }
            
        }

        public int getPID()
        {
            return this.PIDs[0];
        }

        private void threadRun(int threadIndex)
        {
            qaacTask t = rp.getTask();
            qaacTask next;
            
            for (int i = 0; i < this.num; i++)
            {         
                
                if (i != 0)
                {
                    rp.removeTask(t, false);            // false表示成功完成编码没有失败
                }
                this.isfinished[threadIndex] = false;   
                this.runTask(t, this.rsForm.process);
                //MessageBox.Show("Finished!");
                string lastCommandLineOutput = "qaacGUI v0.1";
                while (this.isfinished[threadIndex] == false)
                {
                    Thread.Sleep(500);
                }
                this.rsForm.setStopBtnState(true);
                //while (!String.Equals(lastCommandLineOutput, this.rsForm.getCommandLine())) // 状态指示未完成时一直在此等待
                //{
                //    lastCommandLineOutput = this.rsForm.getCommandLine();
                //    Thread.Sleep(500);    
                //}
                
                next = rp.getTask();                    // get之后任务已从运行池的等待队列中pop出了，无需再次get
                if (next == null)
                {
                    rp.removeTask(t, false); 
                    break;
                }                             
                t = next;
            }
        }

        private void runTask(qaacTask t, Process process)
        {
            // MediaInfo读取音频时长
            MediaInfo MI = new MediaInfo();
            string duration;
            MI.Open(t.filePath);
            duration = MI.Get(StreamKind.Audio, 0, 69);
            //MessageBox.Show(duration);
            if (!String.IsNullOrWhiteSpace(duration))
            {
                rsForm.setTime("0/" + duration);
            }   

            // 运行
            process = new System.Diagnostics.Process();

            process.StartInfo.FileName = "cmd";
 
            // 必须禁用操作系统外壳程序  
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;

            process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Start();

            cmdCode c = new cmdCode(t.filePath, commonCode);
            string cmd = c.cmdCodeGenerate();
            
            //string cmd = "D:/Soft/小丸工具箱rev190/tools/x264_32-8bit.exe D:/Soft/Fraps3.5.99/Fraps/Movies/2015-12-27-2053-55.flv -o 001.mp4";
            process.StandardInput.WriteLine(cmd);

            this.rsForm.setStatusBarFilesCountLabel(this.finishedNum, this.num);

            this.PIDs[0] = process.Id;
           
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
        }
        
        public void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            string finishedWindowTitle = "已完成";
            string unfinishedWindowTitle = "正在转换";
            
            if (!String.IsNullOrEmpty(outLine.Data))
            {      
                StringBuilder sb = new StringBuilder(rsForm.getTB1());
                
                //this.rsForm.setCommandLine(sb.AppendLine(outLine.Data).ToString());
                this.rsForm.setCommandLine(sb.AppendLine(outLine.Data).ToString());
                string finishFlag = "Optimizing...done";
                string o = outLine.Data.ToString();
                if (string.Equals(finishFlag, o))  // 一个文件的编码结束了
                {
                    this.finishedNum++;
                    this.rsForm.setPercent("100.0");
                    this.rsForm.setStopBtnState(false);
                    if (this.finishedNum == this.num)
                    {
                        this.rsForm.setWindowTitle(finishedWindowTitle);
                    }
                    
                    this.rsForm.setStatusBarFilesCountLabel(this.finishedNum, this.num);
                    this.isfinished[0] = true;  // textbox与多线程冲突，暂时不考虑多线程，留待以后解决
                    string empty = "";
                    this.rsForm.setTime(empty);

                    this.rsForm.setEta(empty);
                    Process p = Process.GetProcessById(this.PIDs[0]);
                    p.Kill();

                } else                             // 编码未结束更新进度
                {
                    // 通过ffmpeg读取送到qaac转码
                    // o 的格式 = 时间(速度x) 特征是x)
                    int endIndex = o.IndexOf("x)");
                    int startIndex = o.IndexOf("(");
                    // 速度 xxx.x 最多5位字符，间隔不应大于5
                    if (startIndex != -1 && endIndex != -1 && endIndex - startIndex < 6 && endIndex - startIndex > 0)
                    {
                        string speed = o.Substring(startIndex + 1, endIndex - startIndex - 1);  // 第二个参数是子串的长度
                        this.rsForm.setFps(speed + "x");

                        // 从UI获取音频时长
                        string lastCurrentTimeText = this.rsForm.getCurrentTimeText();
                        int totalTimeStartIndex = lastCurrentTimeText.IndexOf("/") + 1;
                        int totalTimeLength = lastCurrentTimeText.Length - totalTimeStartIndex;
                        string totalTime = lastCurrentTimeText.Substring(totalTimeStartIndex, totalTimeLength);

                        string currentTime = o.Substring(0, startIndex - 1);
                        string time = currentTime + "/" + totalTime;
                        this.rsForm.setTime(time);

                        // 计算百分比
                        // time的格式 HH:MM:SS.XXX (由于qaac输出信息流格式与mediainfo不一致，当前时间没超过一小时的话不会显示HH部分)
                        string[] splitTemp = totalTime.Split(new char[] { ':' });
                        
                        string HH = splitTemp[0];
                        string MM = splitTemp[1];
                        string SSMMM = splitTemp[2];

                        int hr = Convert.ToInt32(HH);
                        int min = Convert.ToInt32(MM);
                        double sec = Convert.ToDouble(SSMMM);
                        double totalTimeValue = hr * 3600 + min * 60 + sec;

                        splitTemp = currentTime.Split(new char[] { ':' });
                        if (splitTemp.Length == 2)
                        {
                            HH = "00";
                            MM = splitTemp[0];
                            SSMMM = splitTemp[1];
                        } else if (splitTemp.Length == 3)
                        {
                            HH = splitTemp[0];
                            MM = splitTemp[1];
                            SSMMM = splitTemp[2];
                        }
                        hr = Convert.ToInt32(HH);
                        min = Convert.ToInt32(MM);
                        sec = Convert.ToDouble(SSMMM);
                        double currentTimeValue = hr * 3600 + min * 60 + sec;
                        double percent = currentTimeValue / totalTimeValue * 99.9;  // 任务未完成情况下最大进度条数值为99.9%
                        
                        // 保留一位小数
                        System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                        nfi.NumberDecimalDigits = 1;
                        
                        this.rsForm.setPercent(percent.ToString("N", nfi));

                        // 计算ETA
                        double remainingTimeValue = totalTimeValue - currentTimeValue;
                        double speedValue = Convert.ToDouble(speed);
                        double etaValue = remainingTimeValue / speedValue;
                        etaValue = etaValue > 1.0 ? etaValue : 1.0;
                        TimeSpan ts = new TimeSpan(0, 0, (int)etaValue);
                        string etaHH = this.convertToTimerFormat(ts.Hours.ToString());
                        string etaMM = this.convertToTimerFormat(ts.Minutes.ToString());
                        string etaSS = this.convertToTimerFormat(ts.Seconds.ToString());
                        
                        string eta = etaHH + ":" + etaMM + ":" + etaSS;
                        this.rsForm.setEta(eta);
                    }
                
                    // 直接qaac读取并转码
                    //int startIndex = o.IndexOf('[');
                    //int endIndex = o.IndexOf(']');
                    //if (startIndex != -1 && endIndex != -1)
                    //{
                    //    // o 的格式 = [进度] 当前时间/总时间 (速度), ETA 剩余时间
                    //    string percent = o.Substring(startIndex + 1, endIndex - startIndex - 2);
                    //    this.rsForm.setPercent(percent);

                    //    //int timeDivIndex = o.IndexOf('/');
                    //    //string currentTime = o.Substring(endIndex + 2, timeDivIndex - endIndex - 2);

                    //    int speedStartIndex = o.IndexOf('(');
                    //    int speedendIndex = o.IndexOf(')');
                    //    //string totalTime = o.Substring(timeDivIndex + 1, speedStartIndex - timeDivIndex - 2);
                    //    string time = o.Substring(endIndex + 2, speedStartIndex - endIndex - 3);
                    //    this.rsForm.setTime(time);

                    //    string speed = o.Substring(speedStartIndex + 1, speedendIndex - speedStartIndex - 1);
                    //    this.rsForm.setFps(speed);

                    //    string eta = o.Substring(speedendIndex + 7).Trim();
                    //    this.rsForm.setEta(eta);
                    //}
                }
            }
        }
  
        private string convertToTimerFormat(string s)
        {
            if (s.Length == 1)
            {
                return "0" + s;
            } else
            {
                return s;
            }
        }
    }
}
