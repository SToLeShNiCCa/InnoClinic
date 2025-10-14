using Application.DTO.Doctors;
using Application.DTO.Result;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorsRepository _repository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<ReadDoctorDTO>> CreateAsync(CreateDoctorDTO doctorDTO, CancellationToken token)
        {
            var doctor = _mapper.Map<Doctor>(doctorDTO);
            await _repository.CreateAsync(doctor, token);
            await _repository.SaveData(token);
            var readDoctorDTO = _mapper.Map<ReadDoctorDTO>(doctor);
            return Result<ReadDoctorDTO>.SuccessResult(readDoctorDTO);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var doctor = await _repository.GetByIdAsync(id,token);
            if (doctor == null) throw new KeyNotFoundException("Doctor not found");

            await _repository.DeleteAsync(doctor, token);
            await _repository.SaveData(token);
        }

        public async Task<IEnumerable<ReadDoctorDTO>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var doctors = await _repository.GetAllAsync(pageInfo, token);

            return _mapper.Map<IEnumerable<ReadDoctorDTO>>(doctors);
        }

        public async Task<ReadDoctorDTO> GetByIdAsync(int id, CancellationToken token)
        {
            var doctor = await _repository.GetByIdAsync(id, token);
            if(doctor == null) throw new KeyNotFoundException("Doctor not found") ;

            var doctorDTO = _mapper.Map<ReadDoctorDTO>(doctor);

            return doctorDTO;
        }

        public async Task UpdateAsync(UpdateDoctorDTO doctorDTO,CancellationToken token)
        {
            var doctor = _mapper.Map<Doctor>(doctorDTO);
            await _repository.UpdateAsync(doctor, token);

            await _repository.SaveData(token);
        }
    }
}
