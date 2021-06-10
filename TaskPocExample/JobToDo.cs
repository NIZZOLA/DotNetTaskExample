using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskPocExample
{
    public class JobToDo
    {
        
        public async void DoWork(ConcurrentBag<(string,string)> logs, string jobName, int interval)
        {
            for(int x = 1; x < 10; x ++ )
            {
                Thread.Sleep(interval);
                logs.Add( new (jobName , DateTime.Now.ToString("mm:ss:ffff")) );
            }
        }

    }
}
