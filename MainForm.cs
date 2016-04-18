using qaacGUI.taskManager;
using qaacGUI.cmdCodeGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace qaacGUI 
{
    public partial class MainForm : Form
    {
        filePathStorage q;

        public MainForm()
        {
            InitializeComponent();
            q = new filePathStorage();

            this.profileCB.SelectedIndex = 0;
            this.codecModeCB.SelectedIndex = 3;

            string defaultOutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\m4a\\";
            this.outputPathTB.Text = defaultOutputFolder;

            CheckForIllegalCrossThreadCalls = false;
        }

        // 点击“开始转换“按钮后
        private void startBtn_Click(object sender, EventArgs e)
        {               
            if (this.fileListlB.Items.Count == 0)
            {
                string noFileMsg = "未添加任何文件";
                MessageBox.Show(noFileMsg);
            }
            else
            {
                // 读取GUI上的编码器参数
                string profile = this.profileCB.Text;
                string type = this.codecModeCB.Text;
                int qp = Convert.ToInt32(this.brORqCB.Text);
                bool cs = this.isAutoALACcB.Checked;
                string outputPath = this.outputPathTB.Text;
                cmdCode c = new cmdCode(profile, type, qp, cs, outputPath);
                this.q.setConfig(c);

                Job j = new Job(this.q);
                j.runJob();  
            }  
        }

        private void addFileBtn_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);  // 默认打开显示我的文档
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            String fp = openFileDialog1.FileName;
                            fileListlB.Items.Add(fp);

                            Thread storageThread = new Thread(() =>
                                {
                                    // TODO:
                                    q.add(fp);
                                });
                            storageThread.Start();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void codecModeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (string.Equals(comboBox.Text, "TVBR"))
            {
                this.brORqLabel.Text = "质量";
                this.addQualityItems();
                this.brORqCB.Text = "91";      // 设置默认值
            } else
            {
                if (string.Equals(this.brORqLabel.Text, "质量"))
                {
                    this.brORqLabel.Text = "码率";
                    this.addBitrateItems();

                    this.brORqCB.Text = "256";     // 设置默认值
                }  
            }      
        }

        private void addQualityItems()
        {
            this.brORqCB.Items.Clear();
            this.brORqCB.Items.Add("0");
            this.brORqCB.Items.Add("9");
            this.brORqCB.Items.Add("18");
            this.brORqCB.Items.Add("27");
            this.brORqCB.Items.Add("36");
            this.brORqCB.Items.Add("45");
            this.brORqCB.Items.Add("54");
            this.brORqCB.Items.Add("63");
            this.brORqCB.Items.Add("73");
            this.brORqCB.Items.Add("82");
            this.brORqCB.Items.Add("91");
            this.brORqCB.Items.Add("100");
            this.brORqCB.Items.Add("109");
            this.brORqCB.Items.Add("118");
            this.brORqCB.Items.Add("127");
        }

        private void addBitrateItems()
        {
            this.brORqCB.Items.Clear();
            this.brORqCB.Items.Add("32");
            this.brORqCB.Items.Add("64");
            this.brORqCB.Items.Add("96");
            this.brORqCB.Items.Add("128");
            this.brORqCB.Items.Add("192");
            this.brORqCB.Items.Add("256");
            this.brORqCB.Items.Add("320");
        }

        private void profileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (string.Equals(comboBox.Text, "HE-AAC"))
            {
                this.codecModeCB.Items.Remove("TVBR");
                this.codecModeCB.SelectedIndex = 0;
                this.brORqLabel.Text = "码率";
                this.addBitrateItems();
                this.brORqCB.Text = "48";     // 设置默认值
            } else
            {
                if (this.codecModeCB.Items.Count == 3)
                {
                    this.codecModeCB.Items.Add("TVBR");
                }
                
                this.codecModeCB.SelectedIndex = 3;
                this.brORqLabel.Text = "质量";
                this.addQualityItems();
                this.brORqCB.Text = "91";      // 设置默认值
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        // 点击右上角X时运行的代码
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Process p = Process.GetCurrentProcess();
            p.Kill();
        }

        private void fileListlB_DragDrop(object sender, DragEventArgs e)
        {
            Array files = ((System.Array)e.Data.GetData(DataFormats.FileDrop));
            int count = files.Length;
            for (int i = 0; i < count; i++)
            {
                string fp = files.GetValue(i).ToString();
                this.fileListlB.Items.Add(fp);

                Thread storageThread = new Thread(() =>
                {
                    // TODO:
                    q.add(fp);
                });
                storageThread.Start();
            }
        }

        private void fileListlB_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None; 
        }

        private void addFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;
                
                string[] files = System.IO.Directory.GetFiles(folderPath);
                int filesCount = files.Length;
                int musicFilesCount = 0;
                for (int i = 0; i < filesCount; i++)
                {
                    string fp = files[i];
                    string[] s = fp.Split(new char[] { '.' });
                    string ext = s[s.Length - 1];
                    if (musicFileCheckByExtension(ext))
                    {
                        musicFilesCount++;
                        fileListlB.Items.Add(fp);

                        Thread storageThread = new Thread(() =>
                        {
                            // TODO:
                            q.add(fp);
                        });
                        storageThread.Start();
                    }
                    
                }
                string msg = "目录搜索完成，找到" + musicFilesCount.ToString() + "个支持的文件";
                MessageBox.Show(msg);
            }
        }
        private bool musicFileCheckByExtension(string extension)
        {
            string[] musicExt = { "mp3", "wma", "wav", "flac", "ape", "aac", "m4a" };
            return this.multiStringEqualCheck(musicExt, extension);
        }
        
        private bool multiStringEqualCheck(string[] targets, string source)
        {
            int len = targets.Length;
            for (int i = 0; i < len; i++)
            {
                if (string.Equals(targets[i], source))
                {
                    return true;
                }
            }
            return false;
        }

        private void removeFileBtn_Click(object sender, EventArgs e)
        {
            string fp = (string)fileListlB.SelectedItem;
            //MessageBox.Show(fp);
            if (fp == null)
            {
                MessageBox.Show("未选择任何任务！");
                return;
            }
            fileListlB.Items.Remove(fp);
            Thread removeThread = new Thread(() =>
            {
                q.remove(fp);
            });
            removeThread.Start();
        }

        private void removeAllBtn_Click(object sender, EventArgs e)
        {
            fileListlB.Items.Clear();
            q.removeAll();
        }

        private void chooseOutputPathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;
                this.outputPathTB.Text = folderPath;
            }
        }
    }
}
