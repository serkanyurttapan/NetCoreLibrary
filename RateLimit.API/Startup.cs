using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.API
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
            //appsetting.json dan veri okumam için ekledim.
            services.AddOptions();

            //bunun sayesinde hangi endpoint üzerinden ne kadar request geldi bilgisini ram (memory) de tutabilirim.
            services.AddMemoryCache();

            //Ip adresleri ile ilgili izinleri vereceðim yerin referansýný ekledim.
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IPRateLimiting"));

            //Policy(Þartname) belirtebilirim. yani belirlenen IP adreslerinin request zamanlarýný belirtebilirim. örn:192.115.648.XX IP si saatte 100 request atabilir gibi durumlarý kontrol edebilirim.
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));

            //Memory cash bilgilerini tuttuðum alaný yazalým.
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();

            /*IP adreslerin sayacýný oluþturacaðým alan oluþturuyorum.
             Yani kaç request yapýldý bilgilerini kullanacaðým yer olacak.*/
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddHttpContextAccessor();

            services.TryAddSingleton<IHttpContextAccessor, IHttpContextAccessor>();

            //Rate limitin ana servisini ekledik.
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIpRateLimiting();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
