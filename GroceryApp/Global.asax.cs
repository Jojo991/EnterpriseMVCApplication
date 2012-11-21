using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using GroceryApp.Models.Services;

namespace GroceryApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        //when application starts
        protected void Application_Start()
        {
          
            //initialize visits---------
            Application.Lock();
            Application["Visits"] = 0;
            Application.UnLock();
            //-------------------------           

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new DropCreateDatabaseTables());
            
        }


        //when session starts
        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            int VisitCount = (int)Application["Visits"];
            VisitCount++;
            Application["Visits"] = VisitCount;
            Application.UnLock();

            Application.Lock();
            Session["IPAddress"] = Request.UserHostAddress.ToString();
            Application.UnLock();
        }
        
    }
}