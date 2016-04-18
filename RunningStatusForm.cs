using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qaacGUI
{
    public partial class RunningStatusForm : Form
    {
        delegate void SetTextCallback(string commandLine);

        public Process process = null;

        public RunningStatusForm()
        {
            InitializeComponent();
        }

        public void setCommandLine(string commandLine)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.fpsDataTB.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setCommandLine);
                this.Invoke(d, new object[] { commandLine });
            }
            else
            {
                this.textBox1.Text = commandLine;
                this.textBox1.SelectionStart = this.textBox1.Text.Length;
                this.textBox1.ScrollToCaret();
            }
            
        }

        public void setPercent(string percent)
        {
            this.progressLabel.Text = percent + "%";
            this.progress.Value = (int)Convert.ToDouble(percent);
        }

        public void setTime(string time)
        {
            this.currentPostionDataTB.Text = time;
            this.currentPostionDataTB.Select(this.currentPostionDataTB.TextLength, 0); 
        }

        public void setFps(string fps)
        {
            this.fpsDataTB.Text = fps;
        }

        public void setEta(string eta)
        {
            this.estETADataTB.Text = eta;
        }

        public string getTB1()
        {
            return this.textBox1.Text;
        }

        private void RunningStatusForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (process != null)
            {
                process.Close();
            }
        }
        public void setStopBtnState(bool enabled)
        {
            this.stopBtn.Enabled = enabled;
        }

        // 点击中止按钮后
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("确定要中止转换吗？","确认中止", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                //点确定的代码
                Process[] p = Process.GetProcessesByName("qaac");
                int count = p.Length;
                for (int i = 0; i < count; i++)
                {
                    p[i].Kill();
                }
                this.stopBtn.Enabled = false;

                string stopWindowTitle = "被用户中止操作";
                this.setWindowTitle(stopWindowTitle);
            }
            else
            { 
                //点取消的代码 
            } 
        } 
 
        public string getCurrentTimeText()
        {
            return this.currentPostionDataTB.Text;
        }

        public string getCommandLine()
        {
            return this.textBox1.Text;
        }

        public void setWindowTitle(string title)
        {
            this.Text = title;
        }

        public void setStatusBarFilesCountLabel(int finished, int all)
        {
            string s = finished.ToString() + "/" + all.ToString();
            this.filesCountLabel.Text = s;
        }
    }
}
