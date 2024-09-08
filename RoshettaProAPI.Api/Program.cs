using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RoshettaProAPI.Core;
using RoshettaProAPI.Core.Base.MiddleWare;
using RoshettaProAPI.Infrustructure;
using RoshettaProAPI.Infrustructure.Context;
using RoshettaProAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ConfigureServices(builder.Services, builder.Configuration);


var app = builder.Build();

// Configure middleware pipeline
ConfigureMiddleware(app);

app.Run();
return;


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    ConfigureSwagger(services);
    ConfigureIdentity(services);
    ConfigureJwtAuthentication(services, configuration);
    ConfigureDatabase(services, configuration);
    RegisterApplicationServices(services);
}
void ConfigureSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "RoshettaProAPI", Version = "v1" });

        var securityScheme = new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "bearer",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "bearer"
            }
        };

        opt.AddSecurityDefinition("bearer", securityScheme);
        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            { securityScheme, new[] { "bearer" } }
        });
    });
}


void ConfigureIdentity(IServiceCollection services)
{
    services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

}
void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration configuration)
{
    var jwtSettings = configuration.GetSection("JWT");
    var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

    services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = JwtRegisteredClaimNames.Sub,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

    services.AddAuthorization();
}


void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
}

void RegisterApplicationServices(IServiceCollection services)
{
    services
        .AddServiceDependencies()
        .AddCoreDependencies()
        .AddInfrastructureDependencies();
}


void ConfigureMiddleware(WebApplication application)
{
    if (application.Environment.IsDevelopment())
    {
        application.UseSwagger();
        application.UseSwaggerUI();
    }
    application.UseMiddleware<ErrorHandlerMiddleware>();


    application.UseHttpsRedirection();
    application.UseRouting();
    application.UseAuthentication();  
    application.UseAuthorization();
    application.MapControllers();
}