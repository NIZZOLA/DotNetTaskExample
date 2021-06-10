using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskPocExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start job execution");
            var lista = new ConcurrentBag<(string,string)>();
            
            List<Task> tasks = new List<Task>();

            tasks.Add(Task.Factory.StartNew(() => new JobToDo().DoWork(lista, "JOB 1", 50) ));
            tasks.Add(Task.Factory.StartNew(() => new JobToDo().DoWork(lista, "JOB 2", 20)));
            tasks.Add(Task.Factory.StartNew(() => new JobToDo().DoWork(lista, "JOB 3", 10)));

            var taskArray = tasks.ToArray();
            
            Task.WaitAll(taskArray);

            foreach (var item in lista.OrderBy(a => a.Item2) )
            {
                Console.WriteLine(item.Item1 + " - " + item.Item2);
            }

        }
    }
}
