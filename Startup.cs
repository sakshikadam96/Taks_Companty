using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product
{
    public class Startup
    {
        public Startup(IConfiguration Configuration) 
        {
            Configuration = Configuration;

        }

        public IConfiguration Configuration { get; }

        //this method gets called by the runtime .use this to add services to the container

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppCon")));
        }

        //this method grt called by the runtime .usr this method to configure the http request pipline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            { 
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //the default HSTS value is 30 days. you may want to change this for production Scenarios
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
