using System.Collections.Generic;
using Clinic.Entity.Models.Patients;

namespace Clinic.Entity.Models.Doctors;

public class Doctor
{
    public Doctor()
    {
        Patients = new HashSet<Patient>();
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Specialty { get; set; }
    public string Address { get; set; }
    public string NationalCode { get; set; }
    public string Mobile { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

    public HashSet<Patient> Patients { get; set; }
}