using FluentMigrator;

namespace Clinic.Migrations;

[Migration(202410011556)]
public class
    _202410011556_InitialPatientTable:Migration
{
    public override void Up()
    {
        Create.Table("Patients")
            .WithColumn("Id").AsInt32()
            .PrimaryKey().Identity()
            .NotNullable()
            .WithColumn("FirstName")
            .AsString().NotNullable()
            .WithColumn("DoctorId").AsInt32().NotNullable();

        Create
            .ForeignKey(
                "FK_Doctors_Patients")
            .FromTable("Patients")
            .ForeignColumn("DoctorId")
            .ToTable("Doctors")
            .PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.Table("Patients");
    }
}