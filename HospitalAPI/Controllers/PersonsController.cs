using HospitalAPI.Person;
using HospitalAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonsController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<PersonDTO>>>> GetAll()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<PersonDTO>>.SuccessResponse(dtos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PersonDTO>>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
                return NotFound(ApiResponse<PersonDTO>.ErrorResponse($"Person with ID {id} not found"));
            return Ok(ApiResponse<PersonDTO>.SuccessResponse(dto));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<PersonDTO>>> Create([FromBody] PersonDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.PersonId },
                ApiResponse<PersonDTO>.SuccessResponse(created, "Person created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<PersonDTO>>> Update(int id, [FromBody] PersonDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound(ApiResponse<PersonDTO>.ErrorResponse($"Person with ID {id} not found"));
            return Ok(ApiResponse<PersonDTO>.SuccessResponse(updated, "Person updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(ApiResponse<object>.ErrorResponse($"Person with ID {id} not found"));
            return Ok(ApiResponse<object>.SuccessResponse(null!, "Person deleted successfully"));
        }
    }
}
