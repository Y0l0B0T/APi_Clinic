using System.Collections.Generic;
using System.Threading.Tasks;
using Clinic.Entity.Models.Doctors;
using Clinic.Entity.Models.Doctors.Dto;

namespace Clinic.Entity.Repositories.Doctors;

public interface DoctorRepository
{
    void Add(Doctor doctor);
    GetDoctorDto GetById(int id);
    bool IsExistById(int id);
    Doctor? Find(int id);

    List<GetDoctorDto> GetAll(
        string? search = null);

    Task Remove(Doctor doctor);
    string GetPatientByDoctorIdAndPatientId(int id, int patientId);
}