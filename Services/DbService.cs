using CW_PD8.DTO;
using CW_PD8.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_PD8.Services
{
    public class DbService : IDbService
    {
        private readonly ProjDbContext _DbContext;

        public DbService(ProjDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }

        public async Task<string> AddDoctorAsync(DoctorDTO dto)
        {
            try
            {
                await _DbContext.AddAsync(new Doctor
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email
                });
                await _DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "There is a doctor with that email!";
            }

            return "Success!";
        }

        public async Task<string> ChangeDoctorAsync(int id, DoctorDTO dto)
        {
            var wantedDoctor = await _DbContext.Doctors.FindAsync(id);

            if (wantedDoctor == null)
                return "Can not find the doctor!";

            wantedDoctor.LastName = dto.LastName;
            wantedDoctor.FirstName = dto.FirstName;
            wantedDoctor.Email = dto.Email;

            await _DbContext.SaveChangesAsync();

            return "Success!";
        }

        public async Task<string> DeleteDoctorAsync(int id)
        {
            var wantedDoctor = await _DbContext.Doctors.FindAsync(id);

            if (wantedDoctor == null)
                return "Can not find the doctor!";

            var isHavingPatiets = await _DbContext.Prescriptions.AnyAsync(e => e.IdDoctor == id);

            if (isHavingPatiets)
                return "Can not delete doctor, because he signed prescriptions to patients!";

            _DbContext.Remove(wantedDoctor);
            await _DbContext.SaveChangesAsync();

            return "Success!";
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctorsAsync()
        {
            return await _DbContext.Doctors.Select(e => new DoctorDTO
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            }).ToListAsync();
        }

        public async Task<PerscriptionDTO> GetPrescriptionAsync(int id)
        {
            var wantedPrescription = await _DbContext.Prescriptions.FindAsync(id);

            if (wantedPrescription == null)
                return null;

            PerscriptionDTO prescriptionDto = await _DbContext
                .Prescriptions
                .Where(e => e.IdPrescription == id)
                .Select(e => new PerscriptionDTO
                {
                    PrescriptionDate = e.Date,
                    PrescriptionDueDate = e.DueDate,
                    PatientFirstName = e.Patient.FirstName,
                    PatientLastName = e.Patient.LastName,
                    PatientBirthDate = e.Patient.BirthDate,
                    DoctorFirstName = e.Doctor.FirstName,
                    DoctorLastName = e.Doctor.LastName,
                    DoctorEmail = e.Doctor.Email,
                    Medicaments = e.Prescrption_Medicaments.Select(e => new MedicamentDTO
                    {
                        Name = e.Medicament.Name,
                        Details = e.Details,
                        Dose = e.Dose
                    })
                }).FirstAsync();

            return prescriptionDto;
        }
    }
}
