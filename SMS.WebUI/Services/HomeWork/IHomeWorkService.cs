using SMS.DtoLayer.HomeWork;

namespace SMS.WebUI.Services.HomeWork
{
    public interface IHomeWorkService
    {
        Task<List<HomeworkListDto>> GetHomeworksByStudentIdAsync(Guid studentId);
        Task<HomeworkListDto?> GetByIdAsync(Guid id);
        Task CreateAsync(HomeWorkCreateDTO dto);
        Task UpdateAsync(HomeWorkUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}