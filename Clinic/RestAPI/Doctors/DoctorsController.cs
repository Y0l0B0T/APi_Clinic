using Clinic.Entity;
using Clinic.Entity.Models.Doctors;
using Clinic.Entity.Models.Doctors.Dto;
using Clinic.Entity.Repositories.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Doctors;

[Route("api/doctors")]
[ApiController]
public class
    DoctorsController : ControllerBase
{
    private readonly DoctorRepository
        _repository;

    private readonly UnitOfWork _unitOfWork;

    public DoctorsController(
        DoctorRepository repository,
        UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    [HttpPost]
    public int Create(
        AddDoctorDto dto)
    {
        var doctor = new Doctor
        {
            Specialty = dto.Specialty,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            NationalCode = dto.NationalCode,
            Address = dto.Address,
            Mobile = dto.Mobile,
            IsActive = true,
            IsDeleted = false,
        };

        _repository.Add(doctor);
        _unitOfWork.Save();
        return doctor.Id;
    }

    [HttpGet("{id}")]
    public GetDoctorDto GetById(int id)
    {
        if (!_repository.IsExistById(id))
        {
            throw new Exception(
                "کاربر یافت نشد");
        }

        return _repository.GetById(id);
    }

    [HttpPut("{id}")]
    public void Update(
        [FromBody] UpdateDoctorDto dto,
        [FromRoute] int id)
    {
        var doctor = _repository.Find(id);
        if (doctor == null)
        {
            throw new Exception(
                "کاربر یافت نشد");
        }

        doctor.NationalCode =
            dto.NationalCode;
        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.Address = dto.Address;
        doctor.Specialty = dto.Specialty;
        doctor.Mobile = dto.Mobile;
        _unitOfWork.Save();
    }

    [HttpGet]
    public List<GetDoctorDto> GetAll([FromQuery] string? search)
    {
        return _repository.GetAll(search);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var doctor = _repository.Find(id);
        if (doctor == null)
        {
            throw new Exception(
                "کاربر یافت نشد");
        }

        await _repository.Remove(doctor);
        _unitOfWork.Save();
    }

    [HttpPatch("{id}/activate")]
    public void Activate(int id)
    {
        var doctor = _repository.Find(id);
        if (doctor == null)
        {
            throw new Exception(
                "کاربر یافت نشد");
        }

        doctor.IsActive = true;
        _unitOfWork.Save();
    }
    
    [HttpPatch("{id}/deactivate")]
    public void Deactivate(int id)
    {
        var doctor = _repository.Find(id);
        if (doctor == null)
        {
            throw new Exception(
                "کاربر یافت نشد");
        }

        doctor.IsActive = false;
        _unitOfWork.Save();
    }

    [HttpGet("{id}/patiests/{patientId}")]
    public string
        GetPatientByDoctorIdAndPatientId(
            int id,
            int patientId)
    {
        return _repository
            .GetPatientByDoctorIdAndPatientId(
                 id,
                 patientId);
    }
}