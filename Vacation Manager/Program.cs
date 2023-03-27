using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vacation_Manager.Data;
using Vacation_Manager.GlobalConstants;

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


            //Създавам функция Authorization
            #region Authorization

            AddAuthorizationPolicies(builder.Services);

            #endregion


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
                {//ако ролята(obj) не съществува - създай
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                    {

                    }
                }
            }

            //Seed-ване на CEO ролята
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string name = "MartinKondakchiev";
                string password = "Test1234,";

                if (await userManager.FindByNameAsync(name) == null)
                {//Проверява дали съществува такъв user
                    var user = new IdentityUser();
                    user.UserName = name;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "CEO");
                }

            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string name = "PetarTenev";
                string password = "TTest1234,";

                if (await userManager.FindByNameAsync(name) == null)
                {//Проверява дали съществува такъв user
                    var user = new IdentityUser();
                    user.UserName = name;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Team Lead");
                }

            }

            app.Run();
        
        }

        //Имплементирам функцията Authorization(за PolicyBasedAuthorization )
        static void AddAuthorizationPolicies(IServiceCollection services)
        {
            services.AddAuthorization(options => 
            {
                options.AddPolicy(RoleConstants.Policies.RequireCEO, policy => policy.RequireRole(RoleConstants.Roles.CEO));//Добавям Policy с име CEO
                options.AddPolicy(RoleConstants.Policies.RequireDeveloper, policy => policy.RequireRole(RoleConstants.Roles.Developer));//Добавям Policy с име Developer
                options.AddPolicy(RoleConstants.Policies.RequireTeamLead, policy => policy.RequireRole(RoleConstants.Roles.TeamLead));//Добавям Policy с име TeamLead
            });                                                                                                                       
        }

        
    }



}



