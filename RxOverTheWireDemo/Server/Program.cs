using System;
using System.Net;
using System.Reactive;
using System.Reactive.Linq;
using Qactive;
using System.Reactive.Subjects;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //IObservable<long> source = Observable.Interval(TimeSpan.FromSeconds(1));
            Subject<long> source = new Subject<long>();



            var service = source.ServeQbservableTcp(new IPEndPoint(IPAddress.Loopback, 3205));

            using (service.Subscribe(
              client => Console.WriteLine("Client shutdown."),
              ex => Console.WriteLine("Fatal error: {0}", ex.Message),
              () => Console.WriteLine("This will never be printed because a service host never completes.")))
            {
                Console.ReadKey();
            }
        }
    }
}
