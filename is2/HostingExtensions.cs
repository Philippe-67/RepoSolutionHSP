using is2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;

namespace IS2
{
    static class HostingExtensions
    {
        /// <summary>
        /// Configuration du serveur d'identité
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        /// 

        //ajout services.AddRazor

        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();////////////////////////////////////////////

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.LoginPath = "/Pages/Account/Login";
           });////////////////////////////////////////////////////////////////////////////////

            builder.Services.AddIdentityServer(options =>
            {
                // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                options.EmitStaticAudienceClaim = true;
            })
             .AddInMemoryClients(Config.Clients)
             .AddInMemoryIdentityResources(Config.IdentityResources) 
             .AddInMemoryApiScopes(Config.ApiScopes)
             //.AddTestUsers(Config.TestUsers)
             .AddTestUsers(TestUsers.Users)
             .AddDeveloperSigningCredential();

            return builder.Build();
        }


        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // uncomment if you want to add a UI
            app.UseStaticFiles();
            app.UseRouting();


            app.UseIdentityServer();
            // uncomment, if you want to add a UI
            app.UseAuthorization();
            app.MapRazorPages().RequireAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


            return app;

        }
    }
}

