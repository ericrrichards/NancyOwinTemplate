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
            startOptions.Urls.Add("https://+:443/HelloWorld");
            _webhost = WebApp.Start<Startup>(startOptions);
            Console.WriteLine("Running on http://localhost/HelloWorld");
        }
    }


    public class Startup {
        public void Configuration(IAppBuilder app) {
            var listener = (HttpListener)app.Properties["System.Net.HttpListener"];
            listener.AuthenticationSchemes = AuthenticationSchemes.Ntlm;

            app.UseNancy();
        }
    }
}
