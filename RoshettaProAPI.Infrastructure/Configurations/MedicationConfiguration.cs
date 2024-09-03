using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.HasKey(m => m.MedicationID);

        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).HasMaxLength(500);
        builder.Property(m => m.SideEffects).HasMaxLength(500);
        builder.Property(m => m.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(m => m.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.HasOne(m => m.MedicationForm)
            .WithMany(mt => mt.Medications)
            .HasForeignKey(m => m.MedicationFormID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            new Medication
            {
                MedicationID = 1, Name = "Panadol", Description = "Used for pain relief and fever reduction",
                SideEffects = "Nausea, Allergic reactions", MedicationFormID = 1, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 2, Name = "Aspirin", Description = "Anti-inflammatory and blood thinner",
                SideEffects = "Gastrointestinal discomfort, Bleeding", MedicationFormID = 1, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 3, Name = "Augmentin", Description = "Antibiotic for bacterial infections",
                SideEffects = "Diarrhea, Allergic reactions", MedicationFormID = 2, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 4, Name = "Cipro", Description = "Antibiotic for bacterial infections",
                SideEffects = "Nausea, Diarrhea", MedicationFormID = 2, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 5, Name = "Lantus", Description = "Insulin for diabetes management",
                SideEffects = "Hypoglycemia, Weight gain", MedicationFormID = 3, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 6, Name = "Glucophage", Description = "Oral medication for type 2 diabetes",
                SideEffects = "Nausea, Diarrhea", MedicationFormID = 3, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 7, Name = "Ventolin", Description = "Bronchodilator for asthma relief",
                SideEffects = "Tremor, Palpitations", MedicationFormID = 4, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 8, Name = "Seretide", Description = "Combination inhaler for asthma",
                SideEffects = "Throat irritation, Hoarseness", MedicationFormID = 4, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 9, Name = "Atorvastatin", Description = "Statin for cholesterol management",
                SideEffects = "Muscle pain, Liver enzyme abnormalities", MedicationFormID = 5,
                CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 10, Name = "Omeprazole", Description = "Proton pump inhibitor for acid reflux",
                SideEffects = "Headache, Abdominal pain", MedicationFormID = 6, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 11, Name = "Amoxicillin", Description = "Antibiotic for bacterial infections",
                SideEffects = "Nausea, Diarrhea", MedicationFormID = 2, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 12, Name = "Zinnat", Description = "Antibiotic for bacterial infections",
                SideEffects = "Nausea, Diarrhea", MedicationFormID = 2, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 13, Name = "Clexane", Description = "Anticoagulant for preventing blood clots",
                SideEffects = "Bleeding, Anemia", MedicationFormID = 7, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 14, Name = "Xarelto", Description = "Anticoagulant for preventing blood clots",
                SideEffects = "Bleeding, Nausea", MedicationFormID = 7, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 15, Name = "Lipitor", Description = "Statin for lowering cholesterol",
                SideEffects = "Muscle pain, Liver enzyme abnormalities", MedicationFormID = 5,
                CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 16, Name = "Crestor", Description = "Statin for lowering cholesterol",
                SideEffects = "Muscle pain, Liver enzyme abnormalities", MedicationFormID = 5,
                CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 17, Name = "Nexium", Description = "Proton pump inhibitor for acid reflux",
                SideEffects = "Headache, Abdominal pain", MedicationFormID = 6, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 18, Name = "Zantac", Description = "H2 blocker for acid reflux",
                SideEffects = "Headache, Dizziness", MedicationFormID = 6, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 19, Name = "Paracetamol", Description = "Used for pain relief and fever reduction",
                SideEffects = "Nausea, Allergic reactions", MedicationFormID = 1, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 20, Name = "Ibuprofen", Description = "Anti-inflammatory and pain relief",
                SideEffects = "Gastrointestinal discomfort, Bleeding", MedicationFormID = 1, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 21, Name = "Voltaren", Description = "Anti-inflammatory and pain relief",
                SideEffects = "Gastrointestinal discomfort, Skin rash", MedicationFormID = 1,
                CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 22, Name = "Brufen", Description = "Anti-inflammatory and pain relief",
                SideEffects = "Gastrointestinal discomfort, Skin rash", MedicationFormID = 1,
                CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 23, Name = "Flagyl", Description = "Antibiotic for anaerobic bacterial infections",
                SideEffects = "Nausea, Metallic taste", MedicationFormID = 2, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 24, Name = "Doxycycline", Description = "Antibiotic for bacterial infections",
                SideEffects = "Nausea, Photosensitivity", MedicationFormID = 2, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 25, Name = "Tavanic", Description = "Antibiotic for bacterial infections",
                SideEffects = "Nausea, Diarrhea", MedicationFormID = 2, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 26, Name = "Moxifloxacin", Description = "Antibiotic for bacterial infections",
                SideEffects = "Nausea, Dizziness", MedicationFormID = 2, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 27, Name = "Prednisolone", Description = "Corticosteroid for inflammation and allergies",
                SideEffects = "Weight gain, Mood swings", MedicationFormID = 8, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 28, Name = "Hydrocortisone",
                Description = "Corticosteroid for inflammation and allergies",
                SideEffects = "Weight gain, Skin thinning", MedicationFormID = 8, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 29, Name = "Methotrexate", Description = "Immunosuppressant for rheumatoid arthritis",
                SideEffects = "Nausea, Liver damage", MedicationFormID = 9, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 30, Name = "Humira", Description = "Immunosuppressant for rheumatoid arthritis",
                SideEffects = "Injection site reactions, Infections", MedicationFormID = 9, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 31, Name = "Enbrel", Description = "Immunosuppressant for rheumatoid arthritis",
                SideEffects = "Injection site reactions, Infections", MedicationFormID = 9, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 32, Name = "Plaquenil", Description = "Immunosuppressant for rheumatoid arthritis",
                SideEffects = "Nausea, Vision changes", MedicationFormID = 9, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 33, Name = "Tamiflu", Description = "Antiviral for influenza",
                SideEffects = "Nausea, Vomiting", MedicationFormID = 10, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 34, Name = "Zovirax", Description = "Antiviral for herpes infections",
                SideEffects = "Nausea, Diarrhea", MedicationFormID = 10, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 35, Name = "Valtrex", Description = "Antiviral for herpes infections",
                SideEffects = "Nausea, Headache", MedicationFormID = 10, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 36, Name = "Zofran", Description = "Antiemetic for nausea and vomiting",
                SideEffects = "Headache, Dizziness", MedicationFormID = 11, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 37, Name = "Domperidone", Description = "Antiemetic for nausea and vomiting",
                SideEffects = "Dry mouth, Drowsiness", MedicationFormID = 11, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 38, Name = "Amlodipine", Description = "Calcium channel blocker for hypertension",
                SideEffects = "Swelling, Dizziness", MedicationFormID = 1, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 39, Name = "Captopril", Description = "ACE inhibitor for hypertension",
                SideEffects = "Cough, Elevated blood potassium", MedicationFormID = 2, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 40, Name = "Losartan", Description = "Angiotensin receptor blocker for hypertension",
                SideEffects = "Dizziness, Back pain", MedicationFormID = 3, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 41, Name = "Norvasc", Description = "Calcium channel blocker for hypertension",
                SideEffects = "Swelling, Dizziness", MedicationFormID = 4, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 42, Name = "Lasix", Description = "Diuretic for edema and hypertension",
                SideEffects = "Dehydration, Electrolyte imbalance", MedicationFormID = 5, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 43, Name = "Spironolactone", Description = "Potassium-sparing diuretic",
                SideEffects = "Hyperkalemia, Gynecomastia", MedicationFormID = 6, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 44, Name = "Aldactone", Description = "Potassium-sparing diuretic",
                SideEffects = "Hyperkalemia, Gynecomastia", MedicationFormID = 7, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 45, Name = "Warfarin", Description = "Anticoagulant for preventing blood clots",
                SideEffects = "Bleeding, Nausea", MedicationFormID = 7, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 46, Name = "Heparin", Description = "Anticoagulant for preventing blood clots",
                SideEffects = "Bleeding, Anemia", MedicationFormID = 7, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 47, Name = "Levothyroxine", Description = "Hormone replacement for hypothyroidism",
                SideEffects = "Palpitations, Weight loss", MedicationFormID = 8, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 48, Name = "Euthyrox", Description = "Hormone replacement for hypothyroidism",
                SideEffects = "Palpitations, Weight loss", MedicationFormID = 9, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 49, Name = "Synthroid", Description = "Hormone replacement for hypothyroidism",
                SideEffects = "Palpitations, Weight loss", MedicationFormID = 10, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Medication
            {
                MedicationID = 50, Name = "Duloxetine", Description = "SNRI for depression and anxiety",
                SideEffects = "Nausea, Dry mouth", MedicationFormID = 11, CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            }
        );
    }
}