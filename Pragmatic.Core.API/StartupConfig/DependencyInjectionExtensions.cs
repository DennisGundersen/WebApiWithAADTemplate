using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Pragmatic.Core.DAL.DataAccess;
using Pragmatic.Core.DAL.Repositories;

namespace Pragmatic.Core.API.StartupConfig;

public static class DependencyInjectionExtensions
{
    public static void AddAuthenticationServices(this WebApplicationBuilder builder)
    {
        // Authentication
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
    }

    public static void AddCustomServices(this WebApplicationBuilder builder)
    {
        // My services
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddSingleton<IValuesRepository, ValuesRepository>();
    }

    public static void AddStandardServices(this WebApplicationBuilder builder)
    {
        // Standard services
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }


}
