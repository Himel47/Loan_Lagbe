using LoanData.DBContext;
using LoanService.ServiceInterface;
using LoanService.Service;
using Microsoft.EntityFrameworkCore;

namespace LoanProject;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        builder.Services.AddDbContext<MyContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBString")
        ));
        builder.Services.AddScoped<IMemberService, MemberService>();
        builder.Services.AddScoped<IGroupService, GroupService>();
        builder.Services.AddScoped<IApiGroupService, ApiGroupService>();
        builder.Services.AddScoped<ILoanPlanService, LoanPlanService>();


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

        app.Run();
    }
}