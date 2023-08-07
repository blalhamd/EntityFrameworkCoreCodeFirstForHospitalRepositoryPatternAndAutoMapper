using AutoMapper;
using DomainModels.Entities;
using DomainModels.EntitiesDTOS;
using DomainModels.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddelLayer.Interfaces;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IGenericRepository<Appointment> _AppointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentController(IGenericRepository<Appointment> AppointmentRepository, IMapper mapper)
        {
            _AppointmentRepository = AppointmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var query = await _AppointmentRepository.GetAll();

            if (query is null)
                return NotFound("Not Exist Appointments");

            var map= _mapper.Map<IEnumerable<AppointmentDTO>>(query);
            
            return Ok(map);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var query = await _AppointmentRepository.GetById(id);

            if (query is null)
                return NotFound("Appointment is not exist");

            var map = _mapper.Map<AppointmentDTO>(query);

            return Ok(map);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetAppointmentByAddress(StatusAppointment status)
        {
            var query = await _AppointmentRepository.GetByCondition(x => x.status == status);

            if (query is null)
                return NotFound("Appointment is not exist");

            var map = _mapper.Map<IEnumerable<AppointmentDTO>>(query);

            return Ok(map);
        }

        [HttpGet("patientId")]
        public async Task<IActionResult> GetAppointmentByPatiendId(int patientId)
        {
            var query = await _AppointmentRepository.GetByCondition(x => x.patientId == patientId);

            if (query is null)
                return NotFound("Appointment is not exist");

            var map = _mapper.Map<IEnumerable<AppointmentDTO>>(query);

            return Ok(map);
        }

        [HttpGet("doctorId")]
        public async Task<IActionResult> GetAppointmentByDoctorId(int doctorId)
        {
            var query = await _AppointmentRepository.GetByCondition(x => x.doctorId == doctorId);

            if (query is null)
                return NotFound("Appointment is not exist");

            var map = _mapper.Map<IEnumerable<AppointmentDTO>>(query);

            return Ok(map);
        }


        [HttpPost]
        public async Task<IActionResult> addAppointment([FromBody] AppointmentDTO Appointmentdto)
        {
            if (Appointmentdto is null)
                return BadRequest("Appointment is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            var map= _mapper.Map<Appointment>(Appointmentdto);

            _AppointmentRepository.Add(map);
            _AppointmentRepository.Save();
            
            return Ok(map);
        }

        [HttpPost("Range")]
        public async Task<IActionResult> addRangeAppointment([FromBody] List<AppointmentDTO> Appointmentdtos)
        {
            if (Appointmentdtos is null)
                return BadRequest("Appointments is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            List<Appointment> Appointments = new List<Appointment>();

            foreach (var item in Appointmentdtos)
            {

                var map = _mapper.Map<Appointment>(item);

                Appointments.Add(map);
            }

            _AppointmentRepository.AddRange(Appointments);
            _AppointmentRepository.Save();

            return Ok(Appointments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateAppointment([FromBody] AppointmentDTO AppointmentDTO, int id)
        {
            var search = await _AppointmentRepository.GetById(id);

            if (search is null)
                return NotFound("Appointment is not exist");

            if (AppointmentDTO is null)
                return BadRequest("Appointment is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            var map= _mapper.Map(AppointmentDTO, search);

            _AppointmentRepository.Update(map);
            _AppointmentRepository.Save();

            return Ok(map);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAppointment(int id)
        {
            var search = await _AppointmentRepository.GetById(id);

            if (search is null)
                return NotFound("Appointment is not exist");

            _AppointmentRepository.Delete(search);
            _AppointmentRepository.Save();

            return Ok(search);
        }

    }
}
