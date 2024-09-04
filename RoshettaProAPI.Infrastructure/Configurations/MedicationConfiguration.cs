using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Data.Enums;

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

        builder.Property(m => m.MedicationForm)
            .IsRequired()
            .HasConversion<int>(); 

        builder.HasData(
    new Medication
    {
        MedicationID = 1,
        Name = "Panadol",
        Description = "Used for pain relief and fever reduction",
        SideEffects = "Nausea, Allergic reactions",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 2,
        Name = "Aspirin",
        Description = "Anti-inflammatory and blood thinner",
        SideEffects = "Gastrointestinal discomfort, Bleeding",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 3,
        Name = "Amoxicillin",
        Description = "Antibiotic for bacterial infections",
        SideEffects = "Diarrhea, Allergic reactions",
        MedicationForm = MedicationForm.Capsule,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 4,
        Name = "Paracetamol Syrup",
        Description = "Pain relief and fever reduction for children",
        SideEffects = "Liver damage in high doses",
        MedicationForm = MedicationForm.Syrup,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 5,
        Name = "Hydrocortisone Cream",
        Description = "Topical treatment for skin inflammation",
        SideEffects = "Skin thinning, Allergic reactions",
        MedicationForm = MedicationForm.Ointment,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 6,
        Name = "Insulin Injection",
        Description = "Used for blood sugar control in diabetes",
        SideEffects = "Hypoglycemia, Allergic reactions",
        MedicationForm = MedicationForm.Injection,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 7,
        Name = "Ondansetron Suppository",
        Description = "Prevents nausea and vomiting",
        SideEffects = "Headache, Fatigue",
        MedicationForm = MedicationForm.Suppository,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 8,
        Name = "Fentanyl Patch",
        Description = "Opioid pain medication for severe pain",
        SideEffects = "Drowsiness, Addiction",
        MedicationForm = MedicationForm.Patch,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 9,
        Name = "Ibuprofen Liquid",
        Description = "Nonsteroidal anti-inflammatory drug (NSAID)",
        SideEffects = "Gastrointestinal discomfort, Kidney damage",
        MedicationForm = MedicationForm.Liquid,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 10,
        Name = "Metamucil Powder",
        Description = "Fiber supplement for digestive health",
        SideEffects = "Bloating, Gas",
        MedicationForm = MedicationForm.Powder,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 11,
        Name = "Diclofenac Gel",
        Description = "Topical NSAID for pain and inflammation",
        SideEffects = "Skin irritation, Allergic reactions",
        MedicationForm = MedicationForm.Gel,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 12,
        Name = "Throat Lozenges",
        Description = "Sore throat relief",
        SideEffects = "Mouth irritation, Allergic reactions",
        MedicationForm = MedicationForm.Capsule,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 13,
        Name = "Albuterol Inhaler",
        Description = "Bronchodilator for asthma",
        SideEffects = "Tremors, Increased heart rate",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 14,
        Name = "Morphine Injection",
        Description = "Opioid pain relief for severe pain",
        SideEffects = "Drowsiness, Addiction",
        MedicationForm = MedicationForm.Injection,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 15,
        Name = "Tylenol Tablet",
        Description = "Pain relief and fever reducer",
        SideEffects = "Liver damage in high doses",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 16,
        Name = "Miconazole Cream",
        Description = "Antifungal for skin infections",
        SideEffects = "Skin irritation, Allergic reactions",
        MedicationForm = MedicationForm.Ointment,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 17,
        Name = "Penicillin Tablet",
        Description = "Antibiotic for bacterial infections",
        SideEffects = "Diarrhea, Allergic reactions",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 18,
        Name = "Dextromethorphan Syrup",
        Description = "Cough suppressant",
        SideEffects = "Drowsiness, Dizziness",
        MedicationForm = MedicationForm.Syrup,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 19,
        Name = "Prednisolone Oral Liquid",
        Description = "Corticosteroid for inflammation",
        SideEffects = "Increased appetite, Mood changes",
        MedicationForm = MedicationForm.Liquid,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 20,
        Name = "Warfarin Tablet",
        Description = "Blood thinner to prevent clots",
        SideEffects = "Bleeding, Bruising",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 21,
        Name = "Gaviscon Liquid",
        Description = "Relieves heartburn and indigestion",
        SideEffects = "Nausea, Constipation",
        MedicationForm = MedicationForm.Liquid,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 22,
        Name = "Clindamycin Capsule",
        Description = "Antibiotic for serious bacterial infections",
        SideEffects = "Diarrhea, Allergic reactions",
        MedicationForm = MedicationForm.Capsule,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 23,
        Name = "Naproxen Tablet",
        Description = "NSAID for pain and inflammation",
        SideEffects = "Gastrointestinal discomfort, Dizziness",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 24,
        Name = "Loratadine Tablet",
        Description = "Antihistamine for allergy relief",
        SideEffects = "Dry mouth, Drowsiness",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 25,
        Name = "Mupirocin Ointment",
        Description = "Topical antibiotic for skin infections",
        SideEffects = "Skin irritation, Burning",
        MedicationForm = MedicationForm.Ointment,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 26,
        Name = "Cetirizine Syrup",
        Description = "Antihistamine for allergy relief",
        SideEffects = "Drowsiness, Dry mouth",
        MedicationForm = MedicationForm.Syrup,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 27,
        Name = "Propranolol Tablet",
        Description = "Beta-blocker for blood pressure and anxiety",
        SideEffects = "Dizziness, Fatigue",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 28,
        Name = "Omeprazole Capsule",
        Description = "Proton pump inhibitor for acid reflux",
        SideEffects = "Headache, Diarrhea",
        MedicationForm = MedicationForm.Capsule,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 29,
        Name = "Doxycycline Tablet",
        Description = "Antibiotic for bacterial infections",
        SideEffects = "Photosensitivity, Nausea",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 30,
        Name = "Ranitidine Tablet",
        Description = "H2 blocker for acid reflux",
        SideEffects = "Headache, Constipation",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 31,
        Name = "Trimethoprim Tablet",
        Description = "Antibiotic for urinary tract infections",
        SideEffects = "Nausea, Rash",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 32,
        Name = "Metronidazole Tablet",
        Description = "Antibiotic for anaerobic infections",
        SideEffects = "Nausea, Metallic taste",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 33,
        Name = "Tretinoin Cream",
        Description = "Topical retinoid for acne",
        SideEffects = "Skin irritation, Redness",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 34,
        Name = "Ketoconazole Shampoo",
        Description = "Antifungal shampoo for dandruff",
        SideEffects = "Skin irritation, Dryness",
        MedicationForm = MedicationForm.Lozenge,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 35,
        Name = "Amphotericin B Injection",
        Description = "Antifungal for serious infections",
        SideEffects = "Fever, Chills",
        MedicationForm = MedicationForm.Injection,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 36,
        Name = "Levothyroxine Tablet",
        Description = "Hormone replacement for hypothyroidism",
        SideEffects = "Palpitations, Weight loss",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 37,
        Name = "Acyclovir Cream",
        Description = "Antiviral for cold sores",
        SideEffects = "Skin irritation, Dryness",
        MedicationForm = MedicationForm.Injection,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 38,
        Name = "Furosemide Tablet",
        Description = "Diuretic for fluid retention",
        SideEffects = "Dehydration, Electrolyte imbalance",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 39,
        Name = "Azithromycin Tablet",
        Description = "Antibiotic for bacterial infections",
        SideEffects = "Nausea, Diarrhea",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 40,
        Name = "Ciprofloxacin Tablet",
        Description = "Antibiotic for bacterial infections",
        SideEffects = "Nausea, Dizziness",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 41,
        Name = "Fluconazole Capsule",
        Description = "Antifungal for yeast infections",
        SideEffects = "Nausea, Headache",
        MedicationForm = MedicationForm.Capsule,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 42,
        Name = "Duloxetine Capsule",
        Description = "SNRI for depression and anxiety",
        SideEffects = "Nausea, Dry mouth",
        MedicationForm = MedicationForm.Capsule,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 43,
        Name = "Lansoprazole Capsule",
        Description = "Proton pump inhibitor for acid reflux",
        SideEffects = "Headache, Diarrhea",
        MedicationForm = MedicationForm.Capsule,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 44,
        Name = "Paroxetine Tablet",
        Description = "SSRI for depression and anxiety",
        SideEffects = "Nausea, Drowsiness",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 45,
        Name = "Gabapentin Capsule",
        Description = "Used for nerve pain and seizures",
        SideEffects = "Dizziness, Fatigue",
        MedicationForm = MedicationForm.Capsule,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 46,
        Name = "Venlafaxine Capsule",
        Description = "SNRI for depression and anxiety",
        SideEffects = "Nausea, Dry mouth",
        MedicationForm = MedicationForm.Capsule,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 47,
        Name = "Melatonin Tablet",
        Description = "Sleep aid for insomnia",
        SideEffects = "Drowsiness, Headache",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 48,
        Name = "Zolpidem Tablet",
        Description = "Sedative for short-term insomnia",
        SideEffects = "Drowsiness, Dizziness",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 49,
        Name = "Simvastatin Tablet",
        Description = "Statin for cholesterol reduction",
        SideEffects = "Muscle pain, Digestive issues",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    },
    new Medication
    {
        MedicationID = 50,
        Name = "Lisinopril Tablet",
        Description = "ACE inhibitor for blood pressure",
        SideEffects = "Cough, Dizziness",
        MedicationForm = MedicationForm.Tablet,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now
    }
);

    }
}