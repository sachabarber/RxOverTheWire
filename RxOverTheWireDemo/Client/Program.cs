using System;
using System.Net;
using System.Reactive;
using System.Reactive.Linq;
using Qactive;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TcpQbservableClient<long>(new IPEndPoint(IPAddress.Loopback, 3205));

            //thie expression tree filtering will happen server side
            //THAT IS AWESOME
            IQbservable<string> query =
              from value in client.Query()
              where value <= 5 || value >= 8
              select string.Format("The incoming value has been doubled to {0}", value * 2);

            using (query.Subscribe(
              value => Console.WriteLine("Client observed: " + value),
              ex => Console.WriteLine("Error: {0}", ex.Message),
              () => Console.WriteLine("Completed")))
            {
                Console.ReadKey();
            }
        }
    }
}
