using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Entity.Context;
using Clinic.Entity.Models.Doctors;
using Clinic.Entity.Models.Doctors.Dto;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Entity.Repositories.Doctors;

public class
    EFDoctorRepository : DoctorRepository
{
    private readonly ApplicationDbContext
        _context;

    public EFDoctorRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
    }

    public GetDoctorDto GetById(int id)
    {
        return _context.Doctors
            .Where(_ => _.Id == id)
            .Select(_ => new GetDoctorDto
            {
                NationalCode =
                    _.NationalCode,
                Address = _.Address,
                Mobile = _.Mobile,
                Specialty = _.Specialty,
                FirstName = _.FirstName,
                LastName = _.LastName
            }).First();
    }

    public bool IsExistById(int id)
    {
        return _context.Doctors.Any(_ =>
            _.Id == id);
    }

    public Doctor? Find(int id)
    {
        return _context.Doctors
            .FirstOrDefault(_ => _.Id == id);
    }

    public List<GetDoctorDto> GetAll(
        string? search)
    {
        var query = _context.Doctors
            .Select(_ => new GetDoctorDto
            {
                NationalCode =
                    _.NationalCode,
                Address = _.Address,
                Mobile = _.Mobile,
                Specialty = _.Specialty,
                FirstName = _.FirstName,
                LastName = _.LastName
            });

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(_ =>
                _.FirstName
                    .Contains(search) ||
                _.LastName.Contains(search));
        }

        return query.ToList();
    }

    public async Task Remove(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
        await Task.CompletedTask;
    }

    public string GetPatientByDoctorIdAndPatientId(
        int id, int patientId)
    {
        return _context.Patients
            .Where(_ =>
                _.DoctorId == id &&
                _.Id == patientId)
            .Select(_ => _.FirstName)
            .First();
    }
}