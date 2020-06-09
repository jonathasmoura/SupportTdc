using Microsoft.AspNetCore.Http;
using td_corp.INFRA.DataContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using td_corp.INFRA.Repositories;
using td_corp.DOMAIN.Repositories;
using td_corp.DOMAIN.MarkingCommandHandlers;
using Newtonsoft.Json;

namespace td_corp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddControllers().AddNewtonsoftJson(o => { o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

            services.AddResponseCompression();
            services.AddMvc();

            services.AddDbContext<CorpContext>(opt => opt.UseInMemoryDatabase("Database"));

            services.AddScoped<CorpContext, CorpContext>();
            services.AddTransient<IMarkingRepository, MarkingRepository>();
            services.AddTransient<MarkingCommandHandler, MarkingCommandHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
