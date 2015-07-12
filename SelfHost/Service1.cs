using System;
using System.Net;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;
using Owin;

namespace SelfHost {
    public partial class Service1 : ServiceBase {
        private IDisposable _webhost;
        public Service1() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            Start();
        }

        protected override void OnStop() {
            if (_webhost != null) {
                _webhost.Dispose();
            }
        }

        public void Start() {
            var startOptions = new StartOptions();
            startOptions.Urls.Add("http://+:80/HelloWorld");
            // If you want to listen on HTTPS as well
            //startOptions.Urls.Add("https://+:443/HelloWorld");
            _webhost = WebApp.Start<Startup>(startOptions);
            Console.WriteLine("Running on http://localhost/HelloWorld");
        }
    }


    public class Startup {
        // OWIN configuration bootstrapper
        public void Configuration(IAppBuilder app) {
            var listener = (HttpListener)app.Properties["System.Net.HttpListener"];
            // Different authentication methods can be specified for the webserver here
            listener.AuthenticationSchemes = AuthenticationSchemes.Ntlm;
            // If you want to support different authentication methods for different URLs
            // you can use listener.AuthenticationSchemeSelectorDelegate and provide the authentication
            // method for different paths
            

            app.UseNancy();
        }
    }
}
