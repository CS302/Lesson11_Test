using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson9_SimpleThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ThreadStart start = Test;
            Thread thread1 = new Thread(start);
            thread1.IsBackground = true;
            thread1.Priority = ThreadPriority.Lowest;
            thread1.Name = "Первый поток";
            thread1.Start();

            Thread thread2 = new Thread(start);
            thread2.IsBackground = true;
            thread2.Priority = ThreadPriority.Highest;
            thread2.Name = "Второй поток";
            thread2.Start();*/

            ParameterizedThreadStart start = Test;
            Thread thread3 = new Thread(start);
            thread3.Start(new int[] { 10, 20 });

            while (Console.ReadLine() != "exit"){}
        }

        static void Test(object data)
        {
            int[] array = (int[])data;
            int a = array[0];
            int b = array[1];
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = a; i < b; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }
    }
}
