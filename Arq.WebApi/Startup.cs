using Arq.Data;
using Arq.Domain;
using Arq.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arq.WebApi
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(op => op
                .UseMySql(_config.GetConnectionString("somedb")));

            services.AddScoped<GenericRepository<CoRequirement>>();
            services.AddScoped<GenericRepository<Course>>();
            services.AddScoped<GenericRepository<Curriculum>>();
            services.AddScoped<GenericRepository<Equivalence>>();
            services.AddScoped<GenericRepository<Prerequisite>>();
            services.AddScoped<GenericRepository<Semester>>();
            services.AddScoped<GenericRepository<Student>>();
            services.AddScoped<GenericRepository<Subject>>();

            services.AddScoped<CurriculumService>();
            services.AddScoped<SubjectsService>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
