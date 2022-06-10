using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Domain;
using Application.Domain.Repositories.Abstract;
using Application.Domain.Repositories.EntityFramework;
using Application;
using Application.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application
{
	public class Startup
	{
		public static bool IsMethodistModeNow;

		public IConfiguration ConfigurationRef;

		public Startup(IConfiguration configuration)
		{
			ConfigurationRef = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<INewsRepository, EFNewsRepository>();
			services.AddTransient<IScheduleRepository, EFScheduleRepository>();
			services.AddTransient<IMessageRepository, EFMessageRepository>();
			services.AddTransient<IScheduleBlockRepository, EFScheduleBlockRepository>();
			services.AddTransient<IStudentRepository, EFStudentRepository>();
			services.AddTransient<IStudentsEstimatesRepository, EFStudentsEstimatesRepository>();
			services.AddTransient<ITeacherRepository, EFTeacherRepository>();
			services.AddTransient<ITeacherSubjectRepository, EFTeacherSubjectRepository>();
			services.AddTransient<ISubjectRepository, EFSubjectRepository>();
			services.AddTransient<IUniversityUserRepository, EFUniversityUserRepository>();
			services.AddTransient<IGroupRepository, EFGroupRepository>();
			services.AddTransient<IGroupSubjectRepository, EFGroupSubjectRepository>();
			services.AddTransient<IUniversityUserRoleRepository, EFUniversityUserRoleRepository>();
			services.AddTransient<IRoleRepository, EFRoleRepository>();
			services.AddTransient<DataManager>();

			services.AddDbContext<AppDbContext>(x => x.UseSqlServer("Data Source=(local); Database=MethodologistSoftware; Persist Security Info=false; User ID='sa'; Password='1234QWERzxc'; MultipleActiveResultSets=True; Trusted_Connection=False;"));

			services.AddIdentity<UniversityUser, IdentityRole>(opts =>
			{
				opts.User.RequireUniqueEmail = true;
				opts.Password.RequiredLength = 8;
				opts.Password.RequireNonAlphanumeric = false;
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireDigit = false;
			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = "auth";
				options.Cookie.HttpOnly = true;
				options.LoginPath = "/account/login";
				options.AccessDeniedPath = "/account/accessdenied";
				options.SlidingExpiration = true;
			});

			services.AddAuthorization(x =>
			{
				x.AddPolicy("MethodistArea", policy => { policy.RequireRole("methodist"); });
				x.AddPolicy("StudentArea", policy => { policy.RequireRole("student"); });
				x.AddPolicy("TeacherArea", policy => { policy.RequireRole("teacher"); });
			});

			services.AddSignalR();
			services.AddControllersWithViews(x =>
			{
				x.Conventions.Add(new MethodistAreaAuthorization("Methodist", "MethodistArea"));
			})
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<ChatHub>("/chat");
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapControllerRoute("home", "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapControllerRoute("news", "{controller=News}/{action=News}/{id?}");
				endpoints.MapControllerRoute("schedule", "{controller=Schedule}/{action=Schedule}/{id?}");
				endpoints.MapControllerRoute("methodist", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
				endpoints.MapControllerRoute("studyingGraph", "{controller=StudyingGraph}/{action=StudyingGraph}/{id?}");
				endpoints.MapControllerRoute("statement", "{controller=Statement}/{action=Statement}/{id?}");
				endpoints.MapAreaControllerRoute("methodist", "Methodist", "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapAreaControllerRoute("student", "Student", "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapAreaControllerRoute("teacher", "Teacher", "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
