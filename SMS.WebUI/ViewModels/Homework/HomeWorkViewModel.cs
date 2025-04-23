using System.ComponentModel.DataAnnotations;

namespace SMS.WebUI.ViewModels.Homework;

public class HomeWorkViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int StudentId { get; set; }
}