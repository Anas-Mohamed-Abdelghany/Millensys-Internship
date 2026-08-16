using HospitalAPI.Patient;
using HospitalAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<PatientWithPersonDTO>>>> GetAll()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<PatientWithPersonDTO>>.SuccessResponse(dtos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PatientWithPersonDTO>>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
                return NotFound(ApiResponse<PatientWithPersonDTO>.ErrorResponse($"Patient with ID {id} not found"));
            return Ok(ApiResponse<PatientWithPersonDTO>.SuccessResponse(dto));
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<PatientWithPersonDTO>>>> GetByStatus(string status)
        {
            var dtos = await _service.GetByStatusAsync(status);
            return Ok(ApiResponse<IEnumerable<PatientWithPersonDTO>>.SuccessResponse(dtos));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<PatientWithPersonDTO>>> Create([FromBody] CreatePatientRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(ApiResponse<PatientWithPersonDTO>.ErrorResponse("Validation failed", errors));
            }

            var dto = await _service.CreateAsync(request);
            return Ok(ApiResponse<PatientWithPersonDTO>.SuccessResponse(dto, "Patient created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<PatientWithPersonDTO>>> Update(int id, [FromBody] CreatePatientRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(ApiResponse<PatientWithPersonDTO>.ErrorResponse("Validation failed", errors));
            }

            var dto = await _service.UpdateAsync(id, request);
            if (dto == null)
                return NotFound(ApiResponse<PatientWithPersonDTO>.ErrorResponse($"Patient with ID {id} not found"));
            return Ok(ApiResponse<PatientWithPersonDTO>.SuccessResponse(dto, "Patient updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(ApiResponse<object>.ErrorResponse($"Patient with ID {id} not found"));
            return Ok(ApiResponse<object>.SuccessResponse(null!, "Patient deleted successfully"));
        }
    }
}
