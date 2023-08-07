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
    public class BillController : ControllerBase
    {
        private readonly IGenericRepository<Bill> _BillRepository;
        private IMapper _mapper;
        public BillController(IGenericRepository<Bill> BillRepository,IMapper mapper)
        {
            _BillRepository = BillRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBills()
        {
            var query = await _BillRepository.GetAll();

            if (query is null)
                return NotFound("Not Exist Bills");

            var map= _mapper.Map<IEnumerable<BillDTO>>(query);

            return Ok(map);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillById(int id)
        {
            var query = await _BillRepository.GetById(id);

            if (query is null)
                return NotFound("Bill is not exist");

            var map = _mapper.Map<BillDTO>(query);

            return Ok(map);
        }


        [HttpGet("status")]
        public async Task<IActionResult> GetBillByAddress(StatusBill status)
        {
            var query = await _BillRepository.GetByCondition(x => x.status == status);

            if (query is null)
                return NotFound("Bill is not exist");

            var map = _mapper.Map<IEnumerable<BillDTO>>(query);

            return Ok(map);
        }


        [HttpGet("patientId")]
        public async Task<IActionResult> GetBillByPatiendId(int patientId)
        {
            var query = await _BillRepository.GetByCondition(x => x.patientId == patientId);

            if (query is null)
                return NotFound("Bill is not exist");

            var map = _mapper.Map<IEnumerable<BillDTO>>(query);

            return Ok(map);
        }


        [HttpPost]
        public async Task<IActionResult> addBill([FromBody] BillDTO Billdto)
        {
            if (Billdto is null)
                return BadRequest("Bill is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

           
            var map = _mapper.Map<Bill>(Billdto);

            _BillRepository.Add(map);
            _BillRepository.Save();

            return Ok(map);
        }

    
        [HttpPost("Range")]
        public async Task<IActionResult> addRangeBill([FromBody] List<BillDTO> Billdtos)
        {
            if (Billdtos is null)
                return BadRequest("Bills is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            List<Bill> Bills = new List<Bill>();

            foreach (var item in Billdtos)
            {

                var map = _mapper.Map<Bill>(item);

                Bills.Add(map);
            }


            _BillRepository.AddRange(Bills);
            _BillRepository.Save();

            return Ok(Bills);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> updateBill([FromBody] BillDTO billDTO, int id)
        {
            var search = await _BillRepository.GetById(id);

            if (search is null)
                return NotFound("Bill is not exist");

            if (billDTO is null)
                return BadRequest("Bill is null");

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            var map= _mapper.Map(billDTO, search);

            _BillRepository.Update(map);
            _BillRepository.Save();

            return Ok(search);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteBill(int id)
        {
            var search = await _BillRepository.GetById(id);

            if (search is null)
                return NotFound("Bill is not exist");

            _BillRepository.Delete(search);
            _BillRepository.Save();

            return Ok(search);
        }
    }
}
