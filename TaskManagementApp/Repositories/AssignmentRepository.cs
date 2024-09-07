using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagementApp.DatabaseAccess;
using TaskManagementApp.DTO.Internal;
using TaskManagementApp.Interfaces.IRepositories;
using TaskManagementApp.Models;

namespace TaskManagementApp.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponseInternalDTO> CreateAssignment(Assignment assignment)
        {
            try
            {
                _context.Tasks.AddAsync(assignment);
                await _context.SaveChangesAsync();
                
                return new GeneralResponseInternalDTO(true, "Task Created");
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
                _context.Remove(assignment);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Task Deleted Successfully");
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
                var result = await _context.Tasks.ToListAsync();
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Tasks not found");
                }

                return new GeneralResponseInternalDTO(true, "Tasks found", result);
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
                var result = await _context.Tasks.FindAsync(taskId);
                if (result == null )
                {
                    return new GeneralResponseInternalDTO(false, "Task not found");   
                }

                return new GeneralResponseInternalDTO(true, "Task found", result);
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
                _context.Tasks.Update(assignment);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Task Updated Successfully");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
