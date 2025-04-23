using System.ComponentModel.DataAnnotations;

namespace SMS.WebUI.ViewModels.Topic;

public class TopicUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Başlık alanı zorunludur.")]
    [Display(Name = "Başlık")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Modül seçimi zorunludur.")]
    [Display(Name = "Modül")]
    public int ModuleId { get; set; }

    [Display(Name = "Durum")]
    public bool? Status { get; set; }
}