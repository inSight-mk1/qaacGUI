using qaacGUI.cmdCodeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qaacGUI.taskManager
{
    class qaacTask
    {
        public string filePath;  // 文件路径（包括文件名和扩展名）
        private bool lossless;   // 是否为无损格式
        public string config;    // 命令行参数

        public qaacTask(string path)  // 初始化文件路径与lossless值
        {
            this.filePath = path;
            this.lossless = isLossless();
        }

        public void setConfig()  // 这个方法于点击开始按钮之后执行
        {
            // 初始化cmdCode
         
            // 根据GUI完成cmdCode并输出字符串

            
        }

        private bool isLossless()
        {
            // 这里写具体的判断过程
            return false;
        }
    }
}
