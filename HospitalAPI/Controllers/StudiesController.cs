using HospitalAPI.Study;
using HospitalAPI.Doctor;
using HospitalAPI.Patient;
using HospitalAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudiesController : ControllerBase
    {
        private readonly IStudyService _service;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public StudiesController(IStudyService service, IDoctorService doctorService, IPatientService patientService)
        {
            _service = service;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<StudyDetailsDTO>>>> GetAll()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<StudyDetailsDTO>>.SuccessResponse(dtos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<StudyDetailsDTO>>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
                return NotFound(ApiResponse<StudyDetailsDTO>.ErrorResponse($"Study with ID {id} not found"));
            return Ok(ApiResponse<StudyDetailsDTO>.SuccessResponse(dto));
        }

        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<StudyDetailsDTO>>>> GetByPatientId(int patientId)
        {
            var dtos = await _service.GetByPatientIdAsync(patientId);
            return Ok(ApiResponse<IEnumerable<StudyDetailsDTO>>.SuccessResponse(dtos));
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<StudyDetailsDTO>>>> GetByDoctorId(int doctorId)
        {
            var dtos = await _service.GetByDoctorIdAsync(doctorId);
            return Ok(ApiResponse<IEnumerable<StudyDetailsDTO>>.SuccessResponse(dtos));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<StudyDetailsDTO>>> Create([FromBody] CreateStudyRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(ApiResponse<StudyDetailsDTO>.ErrorResponse("Validation failed", errors));
            }

            var dto = await _service.CreateAsync(request);
            return Ok(ApiResponse<StudyDetailsDTO>.SuccessResponse(dto, "Study created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<StudyDetailsDTO>>> Update(int id, [FromBody] CreateStudyRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(ApiResponse<StudyDetailsDTO>.ErrorResponse("Validation failed", errors));
            }

            var dto = await _service.UpdateAsync(id, request);
            if (dto == null)
                return NotFound(ApiResponse<StudyDetailsDTO>.ErrorResponse($"Study with ID {id} not found"));
            return Ok(ApiResponse<StudyDetailsDTO>.SuccessResponse(dto, "Study updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(ApiResponse<object>.ErrorResponse($"Study with ID {id} not found"));
            return Ok(ApiResponse<object>.SuccessResponse(null!, "Study deleted successfully"));
        }
    }
}
