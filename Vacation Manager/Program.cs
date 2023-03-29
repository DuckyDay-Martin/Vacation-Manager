using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vacation_Manager.Areas.Identity.Data;
using Vacation_Manager.GlobalConstants;
using Vacation_Manager.GlobalConstants.Repositories;
using Vacation_Manager.Repositories;
using Microsoft.VisualBasic;
using Vacation_Manager.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Authorization

AddAuthorizationPolicies();

#endregion

AddScoped();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();


void AddAuthorizationPolicies()
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(Vacation_Manager.GlobalConstants.RoleConstants.Policies.RequireCEO, policy => policy.RequireRole(Vacation_Manager.GlobalConstants.RoleConstants.Roles.CEO));
        options.AddPolicy(Vacation_Manager.GlobalConstants.RoleConstants.Policies.RequireDeveloper, policy => policy.RequireRole(Vacation_Manager.GlobalConstants.RoleConstants.Roles.Developer));
        options.AddPolicy(Vacation_Manager.GlobalConstants.RoleConstants.Policies.RequireTeamLead, policy => policy.RequireRole(Vacation_Manager.GlobalConstants.RoleConstants.Roles.TeamLead));

    });
}

void AddScoped()
{
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    //builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}