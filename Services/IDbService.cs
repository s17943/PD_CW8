using CW_PD8.DTO;

namespace CW_PD8.Services
{
    public interface IDbService
    {
        Task<IEnumerable<DoctorDTO>> GetDoctorsAsync();
        Task<string> AddDoctorAsync(DoctorDTO dto);
        Task<string> ChangeDoctorAsync(int id, DoctorDTO dto);
        Task<string> DeleteDoctorAsync(int id);
        Task<PerscriptionDTO> GetPrescriptionAsync(int id);
    }
}
