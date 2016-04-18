using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace qaacGUI.cmdCodeGenerator
{
    class filePathStorage
    {
        private string[] storage;
        private int count;
        private bool IOState;
        //private string codecType;
        //private int codecQuantity;
        //private int codecKbps;
        //private string codecProfile;
        //private bool isAutoALAC;
        public cmdCode c;

        private const int maxCount = 1000;

        public filePathStorage()
        {
            this.count = 0;
            this.storage = new string[maxCount];
            this.IOState = false;
            //this.codecKbps = 0;
            //this.codecProfile = "LC-AAC";
            //this.codecQuantity = 91;              // 注意：qaac的TVBR模式质量参数可以为0
            //this.codecType = "TVBR";
            //this.isAutoALAC = false;
        }
        
        //public void setConfig(string profile, string type, int q, bool isAutoALAC)
        //{
        //    this.codecProfile = profile;
        //    this.codecType = type;
        //    if (string.Equals(type, "TVBR") == true)
        //    {
        //        this.codecQuantity = q;
        //    } else
        //    {
        //        this.codecKbps = q;
        //    }
        //    this.isAutoALAC = isAutoALAC;
        //}

        public void setConfig(cmdCode code)
        {
            this.c = code;
        }

        public int Count()
        {
            return this.count;
        }

        public string get(int index)
        {
            return storage[index];
        }

        public void add(string path)
        {
            while (this.IOState == true)  // 如果操作没有完成就阻塞当前线程，防止同时操作导致不可预见的错误
            {
                Thread.Sleep(50); 
            }
            this.IOState = true;
            try
            {
                if (this.count == maxCount)
                {
                    throw new Exception("Overflow");
                } else
                {
                    this.storage[count++] = path;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not add any more tasks. Original error: " + ex.Message);
            }
            this.IOState = false;
        }

        public void remove(string path)
        {
            while (this.IOState == true)
            {
                Thread.Sleep(50);
            }
            this.IOState = true;
            for (int i = 0; i < this.count; i++)
            {
                if (string.Equals(this.storage[i], path))
                {
                    int j;
                    for (j = i; j < this.count;)
                    {
                        this.storage[j] = this.storage[++j];
                    }
                    this.count--;
                    this.IOState = false;
                    return;
                }
            }
            MessageBox.Show("从任务列表中删除失败，请联系开发者！");
            this.IOState = false;
        }
        public void removeAll()
        {
            this.count = 0;
        }
    }
}
