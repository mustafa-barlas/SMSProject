using System.ComponentModel.DataAnnotations;
using SMS.WebUI.ViewModels.Homework;
using SMS.WebUI.ViewModels.StudentModule;

namespace SMS.WebUI.ViewModels.Student;

public class StudentDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
    public List<StudentModuleViewModel> StudentModules { get; set; } = new List<StudentModuleViewModel>();
    public List<HomeWorkViewModel> HomeWorks { get; set; } = new List<HomeWorkViewModel>();
}