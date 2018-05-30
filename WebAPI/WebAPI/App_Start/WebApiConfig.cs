using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using WebAPI.Models.Model;

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
            RegisterRoute(config);
            RegisterDatabase(config);
            RegisterFormat(config);
            RegisterAuthentication(config);
        }

        public static void RegisterRoute(HttpConfiguration config)
        {
            //ModuleHelper.HttpConfiguration.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Default", "{controller}/{action}", new { controller = "Module", action = "TimeServer" });
        }
        public static void RegisterDatabase(HttpConfiguration config)
        {
            //aModel db = (aModel)ModuleHelper.HttpConfiguration.DependencyResolver.GetService(typeof(aModel));
            clsGeneral.connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionDbContext"].ConnectionString;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<zModel, CustomConfiguration>());
            zModel db = new zModel();
            db.Database.Initialize(false);
        }
        public static void RegisterFormat(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            config.Formatters.JsonFormatter.MaxDepth = int.MaxValue;
        }
        public static void RegisterAuthentication(HttpConfiguration config)
        {
            //ModuleHelper.HttpConfiguration.Filters.Add(new CustomAuthorizeAttribute());  
        }
    }
}
