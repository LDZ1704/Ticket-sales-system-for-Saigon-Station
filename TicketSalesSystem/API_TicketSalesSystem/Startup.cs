using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(API_TicketSalesSystem.Startup))]

namespace API_TicketSalesSystem
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host
            var config = new HttpConfiguration();
            
            // Enable attribute routing
            config.MapHttpAttributeRoutes();
            
            // Enable CORS
            //config.EnableCors();
            
            // Add default route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnsureInitialized();

            app.UseWebApi(config);
        }
    }
}
