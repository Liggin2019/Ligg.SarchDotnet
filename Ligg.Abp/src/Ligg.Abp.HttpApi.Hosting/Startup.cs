using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Ligg.Abp.HttpApi.Hosting
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<LiggAbpHttpApiHostingModule>();
            services.AddMvc();
            //Ìí¼ÓCors£¬²¢ÅäÖÃCorsPolicy 
            //services.AddCors(options => options.AddPolicy("AnyCors", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            services.AddCors(options => options.AddPolicy("AnyCors", p => p.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(new[] { "http://localhost:9528" , "http://localhost:5000" })));

        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
            app.UseCors("AnyCors");
        }
    }
}