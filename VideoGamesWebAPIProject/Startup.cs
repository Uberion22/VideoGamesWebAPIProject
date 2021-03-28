using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VideoGamesWebAPIProject.BusinessLogic;
using VideoGamesWebAPIProject.Models;
using VideoGamesWebAPIProject.Repository;

namespace VideoGamesWebAPIProject
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
            string connnection = "Server=(localdb)\\mssqllocaldb;Database=videogamesdb;Trusted_Connection=True;";
            services.AddTransient<IRepository<VideoGame>, MSSQLVideogamesRepository>();
            services.AddTransient<VideoGamesManager>();
            services.AddTransient<VideoGamesContext>();
            services.AddDbContext<VideoGamesContext>(options => options.UseSqlServer(connnection));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
