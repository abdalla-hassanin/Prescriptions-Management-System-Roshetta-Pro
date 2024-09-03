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
        services.AddScoped<IBloodTypeService, BloodTypeService>();
        services.AddScoped<IClinicService, ClinicService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
        services.AddScoped<IMedicationService, MedicationService>();
        services.AddScoped<IMedicationFormService, MedicationFormService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IPatientXrayService, PatientXrayService>();
        services.AddScoped<IPrescriptionService, PrescriptionService>();
        services.AddScoped<IPrescriptionMedicationService, PrescriptionMedicationService>();
        services.AddScoped<ISpecializationService, SpecializationService>();


        return services;
    }
}