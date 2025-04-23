using System.ComponentModel.DataAnnotations;

namespace SMS.WebUI.ViewModels.Student;

public class StudentListViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string ImageUrl { get; set; }
    [Display(Name = "Durum")] 
    public bool? Status { get; set; }
} 
