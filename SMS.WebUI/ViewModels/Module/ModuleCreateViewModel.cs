

using System.ComponentModel.DataAnnotations;

namespace SMS.WebUI.ViewModels.Module;

public class ModuleCreateViewModel
{
    [Required(ErrorMessage = "Başlık alanı zorunludur.")]
    [Display(Name = "Başlık")]
    public string Title { get; set; }

    [Display(Name = "Görsel URL")]
    public string? ImageUrl { get; set; }

    [Display(Name = "Durum")]
    public bool? Status { get; set; }
}