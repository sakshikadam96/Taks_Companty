/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
                         //Home Index
app.Run();
*/




namespace WebAppDotNetCoreCrudNew
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(String[] args) =>

            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(WebBuilder =>
                   {
                WebBuilder.UseStartup<StartupBase>();
        });
        }
    }
