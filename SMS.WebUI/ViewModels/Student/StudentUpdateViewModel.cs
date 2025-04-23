using System.ComponentModel.DataAnnotations;

namespace SMS.WebUI.ViewModels.Student;

public class StudentUpdateViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    [DataType(DataType.Date)] public DateTime DateOfBirth { get; set; }

    public bool Status { get; set; }
    public string ImageUrl { get; set; }
}