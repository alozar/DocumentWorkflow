using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DocumentWorkflow.Models;
using DocumentWorkflow.Services;

namespace DocumentWorkflow
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=document_workflow;Trusted_Connection=True;";
            services.AddDbContext<DWContext>(option => option.UseSqlServer(connectionString));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<DocumentDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Documents}/{action=Index}");
            });
        }
    }
}
