using System;
using System.Net;
using System.Reactive.Linq;
using Qactive;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IObservable<long> source = Observable.Interval(TimeSpan.FromSeconds(1));
            var service = source.ServeQbservableTcp(
                new IPEndPoint(IPAddress.Loopback, 3205),
                new QbservableServiceOptions()
                {
                    SendServerErrorsToClients = true,
                    EnableDuplex = true,
                    AllowExpressionsUnrestricted = true
                }
            );
            using (service.Subscribe(
              client => Console.WriteLine(
                  "Client shutdown."),
              ex => Console.WriteLine(
                  "Fatal error: {0}", ex.Message),
              () => Console.WriteLine(
                  "This will never be printed because a service host never completes.")))
            {
                Console.ReadKey();
            }
        }
    }
}
