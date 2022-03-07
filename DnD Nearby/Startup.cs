using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Services;
using DnD_Nearby.Settings;
using DnD_Nearby.Models;
using DnD_Nearby.Models;
using MongoDB.Bson.Serialization;

namespace DnD_Nearby
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
            var mongoDbSettings = Configuration.GetSection(nameof(MongoDbConfig)).Get<MongoDbConfig>();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(
                    mongoDbSettings.ConnectionString, mongoDbSettings.Name
                );

            services.AddScoped<AccountService>();
            services.AddScoped<PlayerCharacterService>();
            services.AddScoped<StatBlockService>();
            services.AddScoped<SpellService>();
            services.AddScoped<EncounterService>();
            services.AddScoped<PartialPlayerService>();
            services.AddScoped<ItemService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            BsonClassMap.RegisterClassMap<Coins>(cm =>
            {
                cm.MapProperty(coins => coins.Platinum);
                cm.MapProperty(coins => coins.Gold);
                cm.MapProperty(coins => coins.Electrum);
                cm.MapProperty(coins => coins.Silver);
                cm.MapProperty(coins => coins.Copper);
                cm.MapCreator(coins => new Coins(coins.Platinum, coins.Gold, coins.Electrum, coins.Silver, coins.Copper));
            });
        }
    }
}
