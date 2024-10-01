namespace Clinic.Entity.Models.Doctors.Dto;

public class GetDoctorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Specialty { get; set; }
    public string Address { get; set; }
    public string NationalCode { get; set; }
    public string Mobile { get; set; }
}