using System;
using System.ServiceProcess;

namespace SelfHost {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            if (args.Length == 0) {
                var servicesToRun = new ServiceBase[] {new Service1()};
                ServiceBase.Run(servicesToRun);
            } else {
                var service = new Service1();
                service.Start();
                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
                service.Stop();
            }
        }
    }
}
