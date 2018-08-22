using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using WebAPI.Models.Model;
using Common;
using System.Reflection;
using System.Web;

namespace WebAPI
{
    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}

        public static void Register(HttpConfiguration config)
        {
            InitApp(config);
            RegisterRoute(config);
            RegisterDatabase(config);
            RegisterFormat(config);
            RegisterAuthentication(config);
        }

        public static void InitApp(HttpConfiguration config)
        {
            Define.Instance.RootPath = HttpRuntime.AppDomainAppPath;
            Extension.InitApp();
            Log.Debug(MethodBase.GetCurrentMethod());
        }

        public static void RegisterRoute(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("Default", "{controller}/{action}", new { controller = "Module", action = "TimeServer" });
            Log.Debug(MethodBase.GetCurrentMethod());
        }
        public static void RegisterDatabase(HttpConfiguration config)
        {
            //aModel db = (aModel)ModuleHelper.HttpConfiguration.DependencyResolver.GetService(typeof(aModel));
            string conString = string.Empty;
            if (Extension.GetWebSettings("add", "name", "ConnectionDbContext", "connectionString", ref conString))
            {
                Define.Instance.ConnectionString = conString;
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<zModel, CustomConfiguration>());
                zModel db = new zModel();
                db.Database.Initialize(false);
            }
            Log.Debug(MethodBase.GetCurrentMethod());
        }
        public static void RegisterFormat(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            config.Formatters.JsonFormatter.MaxDepth = int.MaxValue;
            Log.Debug(MethodBase.GetCurrentMethod());
        }
        public static void RegisterAuthentication(HttpConfiguration config)
        {
            //ModuleHelper.HttpConfiguration.Filters.Add(new CustomAuthorizeAttribute());  
            Log.Debug(MethodBase.GetCurrentMethod());
        }
    }
}
