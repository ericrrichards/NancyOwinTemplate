using System;
using System.Collections.Generic;
using System.Security.Principal;
using Nancy;
using Nancy.Owin;

namespace SelfHost.Models {
    public class ModelBase {
        protected ModelBase() { }
        public ModelBase(NancyContext context) {
            if (context != null) {
                try {
                    var env = ((IDictionary<string, object>)context.Items[NancyMiddleware.RequestEnvironmentKey]);
                    User = (IPrincipal)env["server.User"];
                } catch (Exception ex) {
                    // log error
                }

            } else {
                // log warning
            }
        }
        public IPrincipal User { get; private set; }
    }
}
