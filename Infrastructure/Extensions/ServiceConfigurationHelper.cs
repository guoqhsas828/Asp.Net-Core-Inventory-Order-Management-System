using System;
using System.Collections.Generic;
using Microsoft.eShopWeb.Infrastructure.Services;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.eShopWeb.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreManager.Data;
using StoreManager.Interfaces;
using StoreManager.Models;
using StoreManager.Services;

namespace Microsoft.eShopWeb.Infrastructure.Extensions
{
  public static class ServiceConfigurationHelper
  {
    public static void ConfigSharedServices(IConfiguration configuration, IServiceCollection services)
    {
      var connStr = configuration.GetConnectionString(
        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production"
          ? "CatalogProdConn" : "DefaultConnection");

      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connStr));

      // Get SendGrid configuration options
      var sendgridSection = configuration.GetSection("SendGridOptions");
      if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
      {
        sendgridSection["SendGridUser"] = Environment.GetEnvironmentVariable("SendGridUser");
      }

      services.Configure<SendGridOptions>(sendgridSection);

      // Get SMTP configuration options
      var smtpSection = configuration.GetSection("SmtpOptions");
      if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
      {
        smtpSection["AcctSid"] = Environment.GetEnvironmentVariable("TwilioSid");
        smtpSection["AcctToken"] = Environment.GetEnvironmentVariable("TwilioToken");
        smtpSection["FromNumber"] = Environment.GetEnvironmentVariable("TwilioNumber");
      }
      services.Configure<SmtpOptions>(smtpSection);

      // Add email services.
      services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
      services.AddTransient<IEmailSender, EmailSender>();
      // Add memory cache services
      services.AddMemoryCache();

      //Configure catalogSettings
      services.Configure<CatalogSettings>(configuration);
      var catalogSettings = configuration.Get<CatalogSettings>();
      var catalogUrl = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production"
       ? Environment.GetEnvironmentVariable("CatalogBaseUrl") : catalogSettings.CatalogBaseUrl;
      catalogSettings.CatalogBaseUrl = catalogUrl;
       services.AddSingleton<IUriComposer>(new UriComposer(catalogSettings));
      
    }

    public static void ConfigureCatalogServices(IConfiguration configuration, IServiceCollection services)
    {
      var connStr = configuration.GetConnectionString(
        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production"
          ? "CatalogProdConn"
          : "DefaultConnection");

      services.AddDbContext<CatalogContext>(c =>
        c.UseSqlServer(connStr));

      services.AddTransient<IFunctional, Functional>();

      services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
      services.AddScoped(typeof(ICatalogRepository<>), typeof(CatalogRepository<>));
      services.AddTransient<IRoles, Roles>();
      services.AddScoped<IBasketService, BasketService>();

      services.AddRouting(options =>
      {
        // Replace the type and the name used to refer to it with your own
        // IOutboundParameterTransformer implementation
        options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
      });

    }
  }
}
