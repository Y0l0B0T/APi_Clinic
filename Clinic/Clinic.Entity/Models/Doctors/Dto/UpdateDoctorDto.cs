using System.ComponentModel.DataAnnotations;

namespace Clinic.Entity.Models.Doctors.Dto;

public class UpdateDoctorDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string? Specialty { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string NationalCode { get; set; }
    [Required]
    public string Mobile { get; set; }
}