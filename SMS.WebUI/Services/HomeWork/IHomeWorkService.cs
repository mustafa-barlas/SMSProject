using SMS.DtoLayer.HomeWork;
using SMS.WebUI.ViewModels.Homework;

namespace SMS.WebUI.Services.HomeWork
{
    public interface IHomeWorkService
    {
        Task<List<HomeWorkViewModel>> GetAllHomeworkByStudentId(int studentId);
        Task<HomeWorkViewModel?> GetByIdAsync(int id);
        Task CreateAsync(HomeWorkCreateDto model);
        Task UpdateAsync(HomeWorkUpdateDto model);
        Task DeleteAsync(int id);
    }
}