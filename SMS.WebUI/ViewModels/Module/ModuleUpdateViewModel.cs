using System.ComponentModel.DataAnnotations;

namespace SMS.WebUI.ViewModels.Module;

public class ModuleUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Başlık alanı zorunludur.")]
    [Display(Name = "Başlık")]
    public string Title { get; set; }

    [Display(Name = "Görsel URL")]
    public string? ImageUrl { get; set; }

    [Display(Name = "Durum")]
    public bool Status { get; set; }
}