using Microsoft.EntityFrameworkCore;
using TaskManagementApp.DTO.Internal;
using TaskManagementApp.Interfaces.IRepositories;
using TaskManagementApp.Interfaces.IServices;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }
        public async Task<GeneralResponseInternalDTO> CreateAssignment(Assignment assignment)
        {
            try
            {
                var result = await _assignmentRepository.CreateAssignment(assignment);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> DeleteAssignment(Assignment assignment)
        {
            try
            {
                var result = await _assignmentRepository.DeleteAssignment(assignment);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> GetAssignment()
        {
            try
            {
                var result = await _assignmentRepository.GetAssignment();
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> GetAssignmentById(string taskId)
        {
            try
            {
                var result = await _assignmentRepository.GetAssignmentById(taskId);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> UpdateAssignment(Assignment assignment)
        {
            try
            {
                var result = await _assignmentRepository.UpdateAssignment(assignment);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
