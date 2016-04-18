using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qaacGUI.taskManager
{
    class runningPool
    {
        public int max;           // 最大允许同时运行任务数
        public qaacTask[] tPool;      // 正在运行的任务数组
        public int currentCount;  // 目前在运行的任务数

        private tasksQueue waitingQueue;
        private tasksQueue completedQueue;
        private tasksQueue failedQueue;

        public delegate void setFpsHandler(string fps);
        public event setFpsHandler setFpsEvent;

        public runningPool(int num, qaacTask[] tasks)      // 默认构造函数，同时运行1个任务
        {
            this.max = 1;
            this.currentCount = 0;
            this.tPool = new qaacTask[this.max];

            // 初始化queue
            this.waitingQueue = new tasksQueue(num, tasks);
            this.completedQueue = new tasksQueue(num);
            this.failedQueue = new tasksQueue(num);
        }

        public qaacTask getTask()
        {          
            // 取一个任务（取出后该任务即从队列中移除了）
            qaacTask t = this.waitingQueue.pop(); 
            if (t != null)
            {
                // 赋config值
                t.setConfig();

                return t;
            }
            return t;  // 如果未取得task，返回null，交job处理           
        }       

        public void removeTask(qaacTask t, bool isfailed)
        {
            // 移动到指定的队列
            if (!isfailed)
            {
                this.completedQueue.add(t);
            }
            else
            {
                this.failedQueue.add(t);
            }
        }
    }
}
