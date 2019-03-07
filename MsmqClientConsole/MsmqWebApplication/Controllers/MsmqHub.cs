using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Messaging;
using System.Threading.Tasks;

namespace MsmqWebApplication.Controllers
{
    public class MsmqHub : Hub
    {
        public MessageQueue queue;
        public void Ping()
        {
            queue = new MessageQueue(MsmqQueueManager.QueueNames.TestQueuePath);
            queue.ReceiveCompleted += Queue_ReceiveCompleted;
            queue.BeginReceive();
        }

        private void Queue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            queue.EndReceive(e.AsyncResult);
            queue.Dispose();
            Clients.All.ping();
        }
    }
}