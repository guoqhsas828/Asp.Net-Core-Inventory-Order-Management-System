using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.eShopWeb.Infrastructure.Extensions;
using Microsoft.eShopWeb.Web;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreManager.Data;
using StoreManager.Models;
using StoreManager.Interfaces;
using StoreManager.Services;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Swashbuckle.AspNetCore.Swagger;

namespace StoreManager
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
      ServiceConfigurationHelper.ConfigSharedServices(Configuration, services);
      ServiceConfigurationHelper.ConfigureCatalogServices(Configuration, services);

      // Get Identity Default Options
      IConfigurationSection identityDefaultOptionsConfigurationSection = Configuration.GetSection("IdentityDefaultOptions");

      services.Configure<IdentityDefaultOptions>(identityDefaultOptionsConfigurationSection);

      var identityDefaultOptions = identityDefaultOptionsConfigurationSection.Get<IdentityDefaultOptions>();

      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
      {
              // Password settings
              options.Password.RequireDigit = identityDefaultOptions.PasswordRequireDigit;
        options.Password.RequiredLength = identityDefaultOptions.PasswordRequiredLength;
        options.Password.RequireNonAlphanumeric = identityDefaultOptions.PasswordRequireNonAlphanumeric;
        options.Password.RequireUppercase = identityDefaultOptions.PasswordRequireUppercase;
        options.Password.RequireLowercase = identityDefaultOptions.PasswordRequireLowercase;
        options.Password.RequiredUniqueChars = identityDefaultOptions.PasswordRequiredUniqueChars;

              // Lockout settings
              options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identityDefaultOptions.LockoutDefaultLockoutTimeSpanInMinutes);
        options.Lockout.MaxFailedAccessAttempts = identityDefaultOptions.LockoutMaxFailedAccessAttempts;
        options.Lockout.AllowedForNewUsers = identityDefaultOptions.LockoutAllowedForNewUsers;

              // User settings
              options.User.RequireUniqueEmail = identityDefaultOptions.UserRequireUniqueEmail;

              // email confirmation require
              options.SignIn.RequireConfirmedEmail = identityDefaultOptions.SignInRequireConfirmedEmail;
      })
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

      // cookie settings
      services.ConfigureApplicationCookie(options =>
      {
              // Cookie settings
              options.Cookie.HttpOnly = identityDefaultOptions.CookieHttpOnly;
        options.Cookie.Expiration = TimeSpan.FromDays(identityDefaultOptions.CookieExpiration);
        options.LoginPath = identityDefaultOptions.LoginPath; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
              options.LogoutPath = identityDefaultOptions.LogoutPath; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
              options.AccessDeniedPath = identityDefaultOptions.AccessDeniedPath; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
              options.SlidingExpiration = identityDefaultOptions.SlidingExpiration;
      });


      // Get Super Admin Default options
      services.Configure<SuperAdminDefaultOptions>(Configuration.GetSection("SuperAdminDefaultOptions"));

      services.AddTransient<INumberSequence, Services.NumberSequence>();

      services.AddMvc()
      .AddJsonOptions(options =>
      {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
              //pascal case json
              options.SerializerSettings.ContractResolver = new DefaultContractResolver();

      });


      services.AddMvc(options =>
          {
            options.Conventions.Add(new RouteTokenTransformerConvention(
              new SlugifyParameterTransformer()));
          }
        )
        .AddRazorPagesOptions(options =>
        {
          options.Conventions.AuthorizePage("/Basket/Checkout");
          options.AllowAreas = true;
        })
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddHttpContextAccessor();
      services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }); });

      //services.AddHealthChecks()
      //  .AddCheck<HomePageHealthCheck>("home_page_health_check")
      //  .AddCheck<ApiHealthCheck>("api_health_check");

      //services.Configure<ServiceConfig>(config =>
      //{
      //  config.Services = new List<ServiceDescriptor>(services);

      //  config.Path = "/allservices";
      //});

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseAuthentication();
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=UserRole}/{action=UserProfile}/{id?}");
      });
    }
  }
}
