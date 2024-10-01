using FluentMigrator;

namespace Clinic.Migrations;

[Migration(202409291431)]
public class _202409291431_InitialDoctorTable:Migration
{
    public override void Up()
    {
        Create.Table("Doctors")
            .WithColumn("Id").AsInt32()
            .PrimaryKey().Identity()
            .NotNullable()
            .WithColumn("FirstName")
            .AsString().NotNullable()
            .WithColumn("LastName")
            .AsString().NotNullable()
            .WithColumn("Specialty")
            .AsString().Nullable();
    }

    public override void Down()
    {
        Delete.Table("Doctors");
    }
}