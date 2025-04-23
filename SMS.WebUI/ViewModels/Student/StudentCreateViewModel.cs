using System.ComponentModel.DataAnnotations;

namespace SMS.WebUI.ViewModels.Student;

public class StudentCreateViewModel
{
    [Required(ErrorMessage = "Ad boş bırakılamaz")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Soyad boş bırakılamaz")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Doğum tarihi zorunludur")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Durum")] public bool Status { get; set; }
    
    [Display(Name = "Resim URL")] public string? ImageUrl { get; set; }
}