using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SMS.WebUI.ViewModels.Homework;

public class HomeworkCreateViewModel
{
    [Required(ErrorMessage = "Başlık alanı zorunludur.")]
    [Display(Name = "Başlık")]
    public string Title { get; set; }

    [Required(ErrorMessage = "İçerik alanı zorunludur.")]
    [Display(Name = "İçerik")]
    public string Content { get; set; }

    [Required(ErrorMessage = "Öğrenci seçimi zorunludur.")]
    [Display(Name = "Öğrenci")]
    public int StudentId { get; set; }

    [Display(Name = "Durum")] public bool? Status { get; set; }

    // Öğrencileri dropdown'da listelemek için:
    public IEnumerable<SelectListItem>? Students { get; set; }
}