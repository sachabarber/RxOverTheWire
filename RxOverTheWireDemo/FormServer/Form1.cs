using System;
using System.Collections.Generic;
using System;
using System.Net;
using System.Reactive;
using System.Reactive.Linq;
using Qactive;
using System.Reactive.Subjects;
using System.Windows.Forms;


namespace FormServer
{
    public partial class Form1 : Form
    {
        Subject<long> source = new Subject<long>();
        long counter = 0;
        IDisposable serverDisposable;

        public Form1()
        {
            InitializeComponent();
            CreateServer();
        }

        private void CreateServer()
        {
            var service = source.ServeQbservableTcp(
                new IPEndPoint(IPAddress.Loopback, 3205),
                new QbservableServiceOptions()
                {
                    SendServerErrorsToClients = true,
                    EnableDuplex = true,
                    AllowExpressionsUnrestricted = true
                }
            );

            serverDisposable = service.Subscribe(
              client => Console.WriteLine("Client shutdown."),
              ex => Console.WriteLine("Fatal error: {0}", ex.Message),
              () => Console.WriteLine("This will never be printed because a service host never completes."));
        }

        private void btnSendItemToClient_Click(object sender, EventArgs e)
        {
            if(counter < 10)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
            source.OnNext(counter);
        }
    }
}
