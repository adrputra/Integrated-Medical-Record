namespace IntegratedMedicalRecord.Server.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly DataContext _context;

        public DoctorService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Doctor>> AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            var result = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctor.Id);

            if (result == null)
            {
                return new ServiceResponse<Doctor>
                {
                    Success = false,
                    Message = $"Failed Add Doctor!"
                };
            }

            return new ServiceResponse<Doctor>
            {
                Success = true,
                Message = $"Successfully Add Doctor!",
                Data = doctor
            };
        }

        public Task<ServiceResponse<bool>> DeleteDoctor(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Doctor>> GetDoctor(int Id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == Id);

            if (doctor == null)
            {
                return new ServiceResponse<Doctor>
                {
                    Success = true,
                    Message = $"Doctor ID {Id} Not Found!"
                };
            }

            return new ServiceResponse<Doctor>
            {
                Success = true,
                Data = doctor
            };
        }

        public async Task<ServiceResponse<List<Doctor>>> GetDoctors()
        {
            var doctor = await _context.Doctors.ToListAsync();

            return new ServiceResponse<List<Doctor>>
            {
                Success = true,
                Data = doctor
            };
        }

        public async Task<ServiceResponse<Doctor>> UpdateDoctor(Doctor doctor)
        {
            var getDoctor = await _context.Doctors
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x =>x.Id == doctor.Id);

            if (getDoctor == null)
            {
                return new ServiceResponse<Doctor>
                {
                    Success = false,
                    Message = $"Doctor ID {doctor.Id} Not Found"
                };
            }

            getDoctor.FirstName = doctor.FirstName;
            getDoctor.LastName = doctor.LastName;
            getDoctor.DepartmentId = doctor.DepartmentId;
            getDoctor.Image = doctor.Image;

            _context.Doctors.Update(getDoctor);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Doctor>
            {
                Success = true,
                Message = $"Successfully Update Doctor!",
                Data = getDoctor
            };
        }
    }
}
