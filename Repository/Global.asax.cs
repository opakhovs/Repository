using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Repository
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<RepositoryContext>());

            using(RepositoryContext context = new RepositoryContext())
            {
                context.ProblemDomains.Add(new ProblemDomain() { Name = "Lolkek", Description = "Lolkek description" });
            }
        }
    }
}
