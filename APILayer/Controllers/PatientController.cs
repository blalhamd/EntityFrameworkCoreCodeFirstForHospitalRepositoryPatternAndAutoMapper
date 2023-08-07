using AutoMapper;
using DomainModels.Entities;
using DomainModels.EntitiesDTOS;
using Microsoft.AspNetCore.Mvc;
using MiddelLayer.Interfaces;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IGenericRepository<Patient> _patientRepository;
        private readonly IMapper _mapper;
        public PatientController(IGenericRepository<Patient> patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var query = await _patientRepository.GetAll();

            if (query is null)
                return NotFound("Not Exist Patients");

            var map= _mapper.Map<IEnumerable<Patient>>(query);
            
            return Ok(map);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var query = await _patientRepository.GetById(id);

            if (query is null)
                return NotFound("Patient is not exist");

            var map = _mapper.Map<Patient>(query);

            return Ok(map);
        }

        [HttpGet("Name")]
        public async Task<IActionResult> GetPatientByName(string name)
        {
            var query = await _patientRepository.GetByCondition(x => x.Name == name);

            if (query is null)
                return NotFound("Patient is not exist");

            var map = _mapper.Map<IEnumerable<Patient>>(query);

            return Ok(map);
        }

        [HttpGet("address")]
        public async Task<IActionResult> GetPatientByAddress(string address)
        {
            var query = await _patientRepository.GetByCondition(x => x.address == address);

            if (query is null)
                return NotFound("Patient is not exist");

            var map = _mapper.Map<IEnumerable<Patient>>(query);

            return Ok(map);
        }

        [HttpGet("Phone")]
        public async Task<IActionResult> GetPatientByPhone(string phone)
        {
            var query = await _patientRepository.GetByCondition(x => x.phone == phone);

            if (query is null)
                return NotFound("Patient is not exist");

            var map = _mapper.Map<IEnumerable<Patient>>(query);

            return Ok(map);
        }

        [HttpPost]
        public async Task<IActionResult> addPatient([FromBody] PatientDTO patientdto)
        {
            if (patientdto is null)
                return BadRequest("Patient is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            var map = _mapper.Map<Patient>(patientdto);

            _patientRepository.Add(map);
            _patientRepository.Save();

            return Ok(map);
        }

        [HttpPost("Range")]
        public async Task<IActionResult> addRangePatient([FromBody] List<PatientDTO> patientdtos)
        {
            if (patientdtos is null)
                return BadRequest("Patients is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            List<Patient> patients = new List<Patient>();

            foreach (var item in patientdtos)
            {

                var map = _mapper.Map<Patient>(item);

                patients.Add(map);
            }


            _patientRepository.AddRange(patients);
            _patientRepository.Save();

            return Ok(patients);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updatePatient([FromBody] PatientDTO patientDTO, int id)
        {
            var search = await _patientRepository.GetById(id);

            if (search is null)
                return NotFound("patient is not exist");

            if (patientDTO is null)
                return BadRequest("patient is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            var map = _mapper.Map(patientDTO, search);

            _patientRepository.Update(map);
            _patientRepository.Save();

            return Ok(map);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletePatient(int id)
        {
            var search = await _patientRepository.GetById(id);

            if (search is null)
                return NotFound("patient is not exist");

            _patientRepository.Delete(search);
            _patientRepository.Save();

            return Ok(search);
        }
    }
}
