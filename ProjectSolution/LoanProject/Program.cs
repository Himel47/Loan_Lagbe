using LoanData.DBContext;
using LoanData.MappingProfile;
using LoanService.Service;
using LoanService.Service.Api;
using LoanService.ServiceInterface;
using LoanService.ServiceInterface.Api;
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
        builder.Services.AddScoped<ILoanPlanService, LoanPlanService>();
        builder.Services.AddScoped<IInstallmentService, InstallmentService>();


        builder.Services.AddScoped<IApiGroupService, ApiGroupService>();
        builder.Services.AddScoped<IApiLoanService, ApiLoanService>();
        builder.Services.AddScoped<IApiInstallmentService, ApiInstallmentService>();

        builder.Services.AddAutoMapper(typeof(Mapping).Assembly);
        builder.Services.AddAutoMapper(typeof(Program).Assembly);


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