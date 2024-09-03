using Microsoft.EntityFrameworkCore;
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
    builder.Services.AddSwaggerGen();
    ConfigureDatabase(services, configuration);
    RegisterApplicationServices(services);
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
        .AddInfrastructureDependencies();
}


void ConfigureMiddleware(WebApplication application)
{
    if (application.Environment.IsDevelopment())
    {
        application.UseSwagger();
        application.UseSwaggerUI();
    }

    application.UseHttpsRedirection();
    application.UseRouting();
    application.UseAuthentication();
    application.UseAuthorization();
    application.MapControllers();
}