using System;
using System.Web.Mvc;
using Fullback.Data;
using Fullback.ServiceInterface;
using Fullback.ServiceInterface.Services;
using Fullback.WebHost.App_Start;
using Fullback.WebHost.Lib;
using Funq;
using Rock.Framework.Logging;
using ServiceStack.Api.Swagger;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using ServiceStack.ServiceHost;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;
using WebActivator;
using Logger = Fullback.WebHost.Lib.Logger;

[assembly: PreApplicationStartMethod(typeof (AppHost), "Start")]

namespace Fullback.WebHost.App_Start
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("Fullback Service", typeof(MailItemsService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            var config = new Config();
            container.Register(new FullBackEntities());
            container.Register(config);

            var endpointHostConfig = new EndpointHostConfig { ServiceStackHandlerFactoryPath = "api" };
            SetConfig(endpointHostConfig);

            JsConfig.EmitCamelCaseNames = true;

            RequestFilters.Add((httpReq, httpResp, requestDto) => Log(httpReq, httpResp));

            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

            Plugins.Add(new SwaggerFeature());
        }

        public static void Start()
        {
            new AppHost().Init();
        }

        private static void Log(IHttpRequest request, IHttpResponse response)
        {
            if (Logger.LogWriter.IsDebugEnabled)
            {
                var entry = new LogEntry(String.Format("API Request {0} {1}", request.HttpMethod, request.GetPathUrl()));
                entry.ExtendedProperties.Add("HTTP Request Path", request.GetPathUrl());
                entry.ExtendedProperties.Add("HTTP Remote IP", request.RemoteIp);
                entry.ExtendedProperties.Add("HTTP Response Status Code", response.StatusCode.ToString());
                entry.ExtendedProperties.Add("HTTP Response Status Description", response.StatusDescription);
                entry.ExtendedProperties.Add("Request DTO", request.ToString());

                Logger.LogWriter.Debug(entry);
            }
        }
    }
}