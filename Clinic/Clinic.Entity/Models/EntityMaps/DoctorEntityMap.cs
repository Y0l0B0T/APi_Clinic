using Clinic.Entity.Models.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Entity.Models.EntityMaps;

public class DoctorEntityMap:IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> _)
    {
        _.ToTable("Doctors")
            .HasKey(_ => _.Id);

        _.Property(_ => _.Id).IsRequired()
            .ValueGeneratedOnAdd();
        _.Property(_ => _.FirstName)
            .IsRequired();
        _.Property(_ => _.LastName)
            .IsRequired();
        _.Property(_ => _.Specialty)
            .IsRequired(false);

        _.Property(_ => _.Address)
            .IsRequired();
        
        _.Property(_ => _.NationalCode)
            .IsRequired();
        
        _.Property(_ => _.Mobile)
            .IsRequired();
        
        _.Property(_ => _.IsActive)
            .IsRequired();
        
        _.Property(_ => _.IsDeleted)
            .IsRequired();
    }
}