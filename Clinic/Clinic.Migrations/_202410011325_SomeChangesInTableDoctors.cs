using FluentMigrator;

namespace Clinic.Migrations;

[Migration(202410011325)]
public class
    _202410011325_SomeChangesInTableDoctors:Migration
{
    public override void Up()
    {
        Alter.Table("Doctors")
            .AddColumn("Address").AsString()
            .NotNullable().WithDefaultValue("not set");
        
        Alter.Table("Doctors")
            .AddColumn("Mobile").AsString()
            .NotNullable().WithDefaultValue("not set");
        
        Alter.Table("Doctors")
            .AddColumn("NationalCode").AsString()
            .NotNullable().WithDefaultValue("not set");

        Alter.Table("Doctors")
            .AddColumn("IsActive").AsBoolean()
            .NotNullable().WithDefaultValue(false);
        
        Alter.Table("Doctors")
            .AddColumn("IsDeleted").AsBoolean()
            .NotNullable().WithDefaultValue(false);
    }

    public override void Down()
    {
        Delete.Column("IsDeleted").FromTable("Doctors");
        Delete.Column("IsActive").FromTable("Doctors");
        Delete.Column("NationalCode").FromTable("Doctors");
        Delete.Column("Mobile").FromTable("Doctors");
        Delete.Column("Address").FromTable("Doctors");
    }
}