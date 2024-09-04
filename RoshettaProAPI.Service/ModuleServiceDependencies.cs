using Microsoft.Extensions.DependencyInjection;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;
using RoshettaProAPI.Service.Service;

namespace RoshettaProAPI.Service;

public static class ModuleServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        // Register the Generic Service
        services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

        // Register Entity Services
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
        services.AddScoped<IMedicationService, MedicationService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IPatientXrayService, PatientXrayService>();
        services.AddScoped<IPrescriptionService, PrescriptionService>();
        services.AddScoped<IPrescriptionMedicationService, PrescriptionMedicationService>();


        return services;
    }
}