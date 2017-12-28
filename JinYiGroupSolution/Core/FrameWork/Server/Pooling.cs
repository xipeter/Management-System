using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Server
{
    public class Pooling
    {
        private static Dictionary<string, long> ticks = new Dictionary<string, long>();
        private static Dictionary<string, bool> timers = new Dictionary<string, bool>();

        private static System.Threading.AutoResetEvent autoEvent = new System.Threading.AutoResetEvent(false);
        private static System.Threading.TimerCallback timerDelegate = null;
        private static System.Threading.Timer timer = null;

        static Pooling()
        {
            if (Management.Connection.TimeOutSecond > 0) //不启动
            {
                timerDelegate = new System.Threading.TimerCallback(timer_Tick);

                //从配置文件中读取timer 的执行间隔时间
                int interval = 6000;
                timer = new System.Threading.Timer(timerDelegate, autoEvent, 0, interval);
            }
        }

        static void timer_Tick(object state)
        {
            long nowTicket = System.DateTime.Now.Ticks;
            //循环Ticks找到各个连接是否应该关闭            
            string[] keys = new string[ticks.Count];
            ticks.Keys.CopyTo(keys, 0);
            foreach (string key in keys)
            //foreach (string key in ticks.Keys)
            {
                if (timers[key] == true)
                {
                    long lastCloseTime = ticks[key];
                    if (nowTicket - lastCloseTime > Management.Connection.TimeOutSecond * 10000000)
                    {
                        //数据库关闭连接处理
                        if (ConnectionPool.GetConnection(key).State == System.Data.ConnectionState.Open ||
                            ConnectionPool.GetConnection(key).State == System.Data.ConnectionState.Connecting)
                        {
                            timers[key] = false;
                            ConnectionPool.GetConnection(key).Close();
                        }

                    }
                }
            }
           
        }
        public static int OpenDB(string applicationID)
        {
            if (timers.ContainsKey(applicationID))
            {
                timers[applicationID] = false;
            }
            else
            {
                timers.Add(applicationID, false);
            }
            
            if (ConnectionPool.GetConnection(applicationID).State == System.Data.ConnectionState.Closed) //没开起事务 
            {
                try
                {
                    //数据库重新开启连接
                    ConnectionPool.GetConnection(applicationID).Open();
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                    return -1;
                }
            }
            return 0;

        }
        public static string Err
        {
            get
            {
                return err;
            }
        }
        static string err;
        public static int CloseDB(string applicationID)
        {
            if (TransactionPool.GetTransaction(applicationID) == null ||
             TransactionPool.GetTransaction(applicationID).Connection == null) //没开起事务 
            {
                
                if (timers.ContainsKey(applicationID))
                {
                    timers[applicationID] = true;
                }
                else
                {
                    timers.Add(applicationID, true);
                }

                if (ticks.ContainsKey(applicationID))
                {
                    ticks[applicationID] = System.DateTime.Now.Ticks;
                }
                else
                {
                    ticks.Add(applicationID, System.DateTime.Now.Ticks);
                }
            }
            return 0;


        }
        private static void GCCollect()
        {
            //强制回收内存
            // GC.Collect();
        }
    }
}
