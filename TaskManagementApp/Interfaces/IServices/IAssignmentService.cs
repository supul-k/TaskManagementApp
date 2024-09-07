using TaskManagementApp.DTO.Internal;
using TaskManagementApp.Models;

namespace TaskManagementApp.Interfaces.IServices
{
    public interface IAssignmentService
    {
        public Task<GeneralResponseInternalDTO> GetAssignmentById(string taskId);

        public Task<GeneralResponseInternalDTO> CreateAssignment(Assignment assignment);

        public Task<GeneralResponseInternalDTO> GetAssignment();

        public Task<GeneralResponseInternalDTO> UpdateAssignment(Assignment assignment);

        public Task<GeneralResponseInternalDTO> DeleteAssignment(Assignment assignment);
    }
}
