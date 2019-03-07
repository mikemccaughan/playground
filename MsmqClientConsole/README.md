# MSMQ Sample

This solution consists of three projects:

1. MsmqQueueManager - Contains shared code between the other projects (currently just a constant for the name of the queue)
2. MsmqClientConsole - Creates the queue if not already present and sends a message every second for three minutes.
3. MsmqWebApplication - Uses [SignalR](https://dotnet.microsoft.com/apps/aspnet/real-time) to update a web page with each message it gets from the queue.

To run the sample:

1. [Install Message Queuing (MSMQ)](https://docs.microsoft.com/en-us/dotnet/framework/wcf/samples/installing-message-queuing-msmq)
2. Run both the MsmqClientConsole and the MsmqWebApplication to see the messages going through the system.
