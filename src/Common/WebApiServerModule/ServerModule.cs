using Nancy;
using Nancy.Bootstrapper;
using Nancy.Extensions;
using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.WebApiServerModule
{
    public class ServerModule : NancyModule
    {
        private static NancyHost _server;
        private static string _endpointName;
        private static Action<string> _cmdFeedback;
        public static void Start(string uri, string endpointName, Action<string> cmdFeedback)
        {
            _endpointName = endpointName;
            _cmdFeedback = cmdFeedback;
            _server = new NancyHost(new Bootstrapper(), new Uri(uri));
            _server.Start();
        }

        public ServerModule()
        {
            Put["/" + _endpointName] = parameters =>
              {
                  _cmdFeedback.Invoke(Request.Body.AsString());
                 
                  return string.Empty;
              };
        }
    }

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        /// <summary>
        /// Register only NancyModules found in this assembly
        /// </summary>
        protected override IEnumerable<ModuleRegistration> Modules
        {
            get
            {
                var x = GetType().Assembly.GetTypes().Where(type => type.BaseType == typeof(NancyModule)).Select(type => new ModuleRegistration(type));
                return x;
            }
        }
    }
}
