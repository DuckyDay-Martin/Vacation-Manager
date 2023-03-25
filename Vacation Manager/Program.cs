using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vacation_Manager.Data;
namespace Vacation_Manager
{ 
    public class Program
    {
        public static async Task Main(string[] args)
        { 
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
        app.UseMigrationsEndPoint();
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

        app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

            //Seed-ване на ролите 
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "CEO", "Developer", "Team Lead", "Unsigned" };

                foreach (var role in roles)
                {//Ако ролята(obj) не съществува създай таква
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                    {

                    }
                }
            }

            //Seed-ване на CEO акаунт
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string name = "MartinKondakchiev";
                string password = "Test1234,";

                if (await userManager.FindByNameAsync(name) == null)
                {//Проверява дали акаунта съществува 
                    var user = new IdentityUser();
                    user.UserName = name;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "CEO");
                }

            }

            //Seed-ване на тестов Unsigned акаунт
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string name = "PetarMalinov";
                string password = "Test1234,1";

                if (await userManager.FindByNameAsync(name) == null)
                {//Проверява дали акаунта съществува 
                    var user = new IdentityUser();
                    user.UserName = name;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Unsigned");
                }

            }
            app.Run();
        
        }
        

    }



}



