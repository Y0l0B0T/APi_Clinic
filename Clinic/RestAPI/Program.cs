using Clinic.Entity;
using Clinic.Entity.Context;
using Clinic.Entity.Repositories.Doctors;
using Microsoft.EntityFrameworkCore;

var builder =
    WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<ApplicationDbContext>(
        option => option.UseSqlServer(
            builder.Configuration
                .GetConnectionString(
                    "DefaultConnection")));

builder.Services.AddScoped<DoctorRepository, EFDoctorRepository>();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
}

app.UseHttpsRedirection();

app.Run();
