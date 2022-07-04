namespace IntegratedMedicalRecord.Server.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<ServiceResponse<List<Doctor>>> GetDoctors();
        Task<ServiceResponse<Doctor>> GetDoctor(int Id);
        Task<ServiceResponse<Doctor>> AddDoctor(Doctor doctor);
        Task<ServiceResponse<bool>> DeleteDoctor(int Id);
        Task<ServiceResponse<Doctor>> UpdateDoctor(Doctor doctor);
    }
}
