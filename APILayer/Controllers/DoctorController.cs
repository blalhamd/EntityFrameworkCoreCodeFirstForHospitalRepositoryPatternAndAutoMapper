using AutoMapper;
using DomainModels.Entities;
using DomainModels.EntitiesDTOS;
using DomainModels.Enums;
using Microsoft.AspNetCore.Mvc;
using MiddelLayer.Interfaces;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IGenericRepository<Doctor> _DoctorRepository;
        private readonly IMapper _mapper;
        public DoctorController(IGenericRepository<Doctor> DoctorRepository, IMapper mapper)
        {
            _DoctorRepository = DoctorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var query = await _DoctorRepository.GetAll();

            if (query is null)
                return NotFound("Not Exist Doctors");

            var map = _mapper.Map<IEnumerable<DoctorDTO>>(query);

            return Ok(map);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var query = await _DoctorRepository.GetById(id);

            if (query is null)
                return NotFound("Doctor is not exist");

            var map = _mapper.Map<DoctorDTO>(query);

            return Ok(map);
        }

        [HttpGet("Name")]
        public async Task<IActionResult> GetDoctorByName(string name)
        {
            var query = await _DoctorRepository.Filtering(x => x.Name == name,x=>x.Name);

            if (query is null)
                return NotFound("Doctor is not exist");

            var map = _mapper.Map<IEnumerable<DoctorDTO>>(query);

            return Ok(map);
        }

        [HttpGet("contact")]
        public async Task<IActionResult> GetDoctorByContact(string contact)
        {
            var query = await _DoctorRepository.GetByCondition(x => x.contact == contact);

            if (query is null)
                return NotFound("Doctor is not exist");

            var map = _mapper.Map<IEnumerable<DoctorDTO>>(query);

            return Ok(map);
        }

        [HttpGet("specialty")]
        public async Task<IActionResult> GetDoctorBySpecialty(Specialty specialty)
        {
            var query = await _DoctorRepository.GetByCondition(x => x.specialty == specialty);

            if (query is null)
                return NotFound("Doctor is not exist");

            var map = _mapper.Map<IEnumerable<DoctorDTO>>(query);

            return Ok(map);
        }

        [HttpPost]
        public async Task<IActionResult> addDoctor([FromBody] DoctorDTO doctordto)
        {
            if (doctordto is null)
                return BadRequest("Doctor is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            var map= _mapper.Map<Doctor>(doctordto);

            _DoctorRepository.Add(map);
            _DoctorRepository.Save();

            return Ok(map);
        }

        [HttpPost("Range")]
        public async Task<IActionResult> addRangeDoctors([FromBody] List<DoctorDTO> doctorDTOs)
        {
            if (doctorDTOs is null)
                return BadRequest("Doctors is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            List<Doctor> Doctors = new List<Doctor>();

            foreach (var item in doctorDTOs)
            {
                var map = _mapper.Map<Doctor>(item);

                Doctors.Add(map);
            }


            _DoctorRepository.AddRange(Doctors);
            _DoctorRepository.Save();

            return Ok(Doctors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateDoctor([FromBody] DoctorDTO doctorDTO, int id)
        {
            var search = await _DoctorRepository.GetById(id);

            if (search is null)
                return NotFound("Doctor is not exist");

            if (doctorDTO is null)
                return BadRequest("Doctor is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            var map = _mapper.Map(doctorDTO, search);

            _DoctorRepository.Update(map);
            _DoctorRepository.Save();

            return Ok(map);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteDoctor(int id)
        {
            var search = await _DoctorRepository.GetById(id);

            if (search is null)
                return NotFound("Doctor is not exist");

            _DoctorRepository.Delete(search);
            _DoctorRepository.Save();

            return Ok(search);
        }
    }
}
