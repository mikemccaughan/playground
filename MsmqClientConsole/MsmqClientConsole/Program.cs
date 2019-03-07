using System;
using System.Messaging;
using System.Threading;

namespace MsmqClientConsole
{
    class Program
    {
        static MessageQueue queue;
        static DateTime started;
        static Timer timer;
        static void Main(string[] args)
        {
            var queuePath = MsmqQueueManager.QueueNames.TestQueuePath;
            if (!MessageQueue.Exists(queuePath))
            {
                queue = MessageQueue.Create(queuePath);
            }
            else
            {
                queue = new MessageQueue(queuePath);
            }

            started = DateTime.Now;
            timer = new Timer(e => SendPing(), null, 0, 1000);
            Console.ReadKey();
        }

        static void SendPing()
        {
            Console.WriteLine("{0:N0}: Sending ping", DateTime.UtcNow.Subtract(new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc)).TotalMilliseconds);
            queue.Send("test");
            if (DateTime.Now.Subtract(started).TotalMinutes >= 3)
            {
                timer.Dispose();
            }
        }
    }
}
