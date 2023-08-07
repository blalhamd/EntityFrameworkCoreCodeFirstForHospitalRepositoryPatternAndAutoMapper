using AutoMapper;
using DomainModels.Entities;
using DomainModels.EntitiesDTOS;
using Microsoft.AspNetCore.Mvc;
using MiddelLayer.Interfaces;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IGenericRepository<Prescription> _PrescriptionRepository;
        private readonly IMapper _mapper;

        public PrescriptionController(IGenericRepository<Prescription> PrescriptionRepository, IMapper mapper)
        {
            _PrescriptionRepository = PrescriptionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var query = await _PrescriptionRepository.GetAll();

            if (query is null)
                return NotFound("Not Exist Prescriptions");

            var map = _mapper.Map<IEnumerable<PrescriptionDTO>>(query);

            return Ok(map);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionById(int id)
        {
            var query = await _PrescriptionRepository.GetById(id);

            if (query is null)
                return NotFound("Prescription is not exist");

            var map = _mapper.Map<Prescription>(query);

            return Ok(map);
        }


        [HttpGet("AppointmentId")]
        public async Task<IActionResult> GetPrescriptionByAppointmentId(int AppointmentId)
        {
            var query = await _PrescriptionRepository.GetByCondition(x => x.AppointmentId == AppointmentId);

            if (query is null)
                return NotFound("Prescription is not exist");

            var map = _mapper.Map<IEnumerable<Prescription>>(query);

            return Ok(map);
        }

        [HttpGet("Medication")]
        public async Task<IActionResult> GetPrescriptionByMedicationId(string medication)
        {
            var query = await _PrescriptionRepository.GetByCondition(x => x.medication == medication);

            if (query is null)
                return NotFound("Prescription is not exist");

            var map = _mapper.Map<IEnumerable<Prescription>>(query);

            return Ok(map);
        }


        [HttpPost]
        public async Task<IActionResult> addPrescription([FromBody] PrescriptionDTO Prescriptiondto)
        {
            if (Prescriptiondto is null)
                return BadRequest("Prescription is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            var map= _mapper.Map<Prescription>(Prescriptiondto);    

            _PrescriptionRepository.Add(map);
            _PrescriptionRepository.Save();

            return Ok(map);
        }

        [HttpPost("Range")]
        public async Task<IActionResult> addRangePrescription([FromBody] List<PrescriptionDTO> Prescriptiondtos)
        {
            if (Prescriptiondtos is null)
                return BadRequest("Prescriptions is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            List<Prescription> Prescriptions = new List<Prescription>();

            foreach (var item in Prescriptiondtos)
            {

                var map = _mapper.Map<Prescription>(item);

                Prescriptions.Add(map);
            }


            _PrescriptionRepository.AddRange(Prescriptions);
            _PrescriptionRepository.Save();

            return Ok(Prescriptions);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updatePrescription([FromBody] PrescriptionDTO PrescriptionDTO, int id)
        {
            var search = await _PrescriptionRepository.GetById(id);

            if (search is null)
                return NotFound("Prescription is not exist");

            if (PrescriptionDTO is null)
                return BadRequest("Prescription is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            var map = _mapper.Map(PrescriptionDTO,search);

            _PrescriptionRepository.Update(map);
            _PrescriptionRepository.Save();

            return Ok(map);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletePrescription(int id)
        {
            var search = await _PrescriptionRepository.GetById(id);

            if (search is null)
                return NotFound("Prescription is not exist");

            _PrescriptionRepository.Delete(search);
            _PrescriptionRepository.Save();

            return Ok(search);
        }
    }
}

