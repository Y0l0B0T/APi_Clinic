using Clinic.Entity.Models.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Entity.Models.EntityMaps;

public class PatientEntityMap:IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> _)
    {
        _.ToTable("Patients")
            .HasKey(_ => _.Id);
        _.Property(_ => _.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        _.Property(_ => _.FirstName)
            .IsRequired();
        
        _.Property(_ => _.DoctorId)
            .IsRequired();

        _.HasOne(_ => _.Doctor)
            .WithMany(_ => _.Patients)
            .HasForeignKey(_ => _.DoctorId)
            .IsRequired();
    }
}