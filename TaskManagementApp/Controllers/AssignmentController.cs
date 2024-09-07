using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.DTO;
using TaskManagementApp.Interfaces.IServices;
using TaskManagementApp.Models;

namespace TaskManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpPost("create-task", Name ="CreateTask")]
        public async Task<IActionResult> CreateAssignment([FromBody] AssignmentRequestDTO request)
        {
            try
            {
                Assignment assignment = new Assignment();
                assignment.Id = Guid.NewGuid().ToString();
                assignment.Title = request.Title;
                assignment.Description = request.Description;
                assignment.DueDate = request.DueDate;
                assignment.Status = request.Status;

                var result = await _assignmentService.CreateAssignment(assignment);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Created(string.Empty,result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResponseDTO(false, ex.Message));
            }      
        }

        [HttpPost("update-task/{taskId}", Name = "UpdateTask")]
        public async Task<IActionResult> UpdateAssignment(string taskId ,[FromBody] AssignmentUpdateDTO request)
        {
            try
            {
                var assignmentResult = await _assignmentService.GetAssignmentById(taskId);
                if (!assignmentResult.Status)
                {
                    return BadRequest(assignmentResult);
                }

                Assignment assignment = assignmentResult.Data as Assignment;

                if (!string.IsNullOrEmpty(request.Title)) assignment.Title = request.Title;
                if (!string.IsNullOrEmpty(request.Description)) assignment.Description = request.Description;
                if (request.DueDate.HasValue) assignment.DueDate = request.DueDate.Value;
                if (request.Status.HasValue) assignment.Status = request.Status.Value;

                var result = await _assignmentService.UpdateAssignment(assignment);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpDelete("delete-task/{taskId}", Name ="DeleteTask")]
        public async Task<IActionResult> DeleteAssignment(string taskId)
        {
            try
            {
                var assignmentresult = await _assignmentService.GetAssignmentById(taskId);
                if (!assignmentresult.Status)
                {
                    return BadRequest(assignmentresult);
                }

                Assignment assignment = assignmentresult.Data as Assignment;

                var result = await _assignmentService.DeleteAssignment(assignment);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpGet("task/{taskId}", Name = "GetTask")]
        public async Task<IActionResult> GetAssignment(string taskId)
        {
            try
            {
                var result = await _assignmentService.GetAssignmentById(taskId);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpGet("tasks", Name = "GetTasks")]
        public async Task<IActionResult> GetAssignments()
        {
            try
            {
                var result = await _assignmentService.GetAssignment();
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResponseDTO(false, ex.Message));
            }
        }
    }
}
