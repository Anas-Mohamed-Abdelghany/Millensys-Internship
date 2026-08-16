using HospitalAPI.Doctor;
using HospitalAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorsController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<DoctorWithPersonDTO>>>> GetAll()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<DoctorWithPersonDTO>>.SuccessResponse(dtos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<DoctorWithPersonDTO>>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
                return NotFound(ApiResponse<DoctorWithPersonDTO>.ErrorResponse($"Doctor with ID {id} not found"));
            return Ok(ApiResponse<DoctorWithPersonDTO>.SuccessResponse(dto));
        }

        [HttpGet("specialty/{specialty}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DoctorWithPersonDTO>>>> GetBySpecialty(string specialty)
        {
            var dtos = await _service.GetBySpecialtyAsync(specialty);
            return Ok(ApiResponse<IEnumerable<DoctorWithPersonDTO>>.SuccessResponse(dtos));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<DoctorWithPersonDTO>>> Create([FromBody] CreateDoctorRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(ApiResponse<DoctorWithPersonDTO>.ErrorResponse("Validation failed", errors));
            }

            var dto = await _service.CreateAsync(request);
            return Ok(ApiResponse<DoctorWithPersonDTO>.SuccessResponse(dto, "Doctor created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<DoctorWithPersonDTO>>> Update(int id, [FromBody] CreateDoctorRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(ApiResponse<DoctorWithPersonDTO>.ErrorResponse("Validation failed", errors));
            }

            var dto = await _service.UpdateAsync(id, request);
            if (dto == null)
                return NotFound(ApiResponse<DoctorWithPersonDTO>.ErrorResponse($"Doctor with ID {id} not found"));
            return Ok(ApiResponse<DoctorWithPersonDTO>.SuccessResponse(dto, "Doctor updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(ApiResponse<object>.ErrorResponse($"Doctor with ID {id} not found"));
            return Ok(ApiResponse<object>.SuccessResponse(null!, "Doctor deleted successfully"));
        }
    }
}
