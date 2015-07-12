using System;
using System.ServiceProcess;

namespace SelfHost {
    static class Program {
        static void Main(string[] args) {
            if (args.Length == 0) {
                // run as a service
                var servicesToRun = new ServiceBase[] {new Service1()};
                ServiceBase.Run(servicesToRun);
            } else {
                // run in a console application
                using (var service = new Service1()) {
                    service.Start();
                    // wait for exit
                    Console.WriteLine("Press enter to exit...");
                    Console.ReadLine();
                    service.Stop();
                }
            }
        }
    }
}
