using Clinic.Entity.Models.Doctors;

namespace Clinic.Entity.Models.Patients;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}