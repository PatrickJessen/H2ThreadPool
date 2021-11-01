using System;
using System.Diagnostics;
using System.Threading;

namespace H2ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("Thread pool Execution");

            stopWatch.Start();
            ProcessWithThreadPoolMethod();
            stopWatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + stopWatch.ElapsedTicks.ToString());
            stopWatch.Reset();
            Console.WriteLine("Thread Execution");

            stopWatch.Start();
            ProcessWithThreadMethod();
            stopWatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + stopWatch.ElapsedTicks.ToString());
            Console.Read();
        }

        public static void Process(object obj)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {
                    // yikes
                }
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
    }
}
