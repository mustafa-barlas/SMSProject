using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.Topic;
using StudentManagement.WebUI.Services.Topic;

namespace StudentManagement.WebUI.Controllers;

public class TopicController(ITopicService topicService) : Controller
{
    // Listeleme
    public async Task<IActionResult> Index()
    {
        var topics = await topicService.GetAllTopicsAsync(true);
        return View(topics);
    }
    
    public async Task<IActionResult> GetAllTopicsWithModuleId()
    {
        var topics = await topicService.GetAllTopicsAsync(true);
        return View(topics);
    }

    // Detay
    public async Task<IActionResult> Detail(Guid id)
    {
        var topic = await topicService.GetTopicByIdAsync(id);
        if (topic == null) return NotFound();
        return View(topic);
    }

    // Oluşturma (GET)
    public IActionResult Create()
    {
        return View();
    }

    // Oluşturma (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TopicCreateDTO dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await topicService.CreateTopicAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // Güncelleme (GET)
    public async Task<IActionResult> Edit(Guid id)
    {
        var topic = await topicService.GetTopicByIdAsync(id);
        if (topic == null) return NotFound();

        var updateDto = new TopicUpdateDTO
        {
            Id = topic.Id,
            TopicName = topic.TopicName,
            ModuleId = topic.ModuleId,
            Status = topic.Status
        };

        return View(updateDto);
    }

    // Güncelleme (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TopicUpdateDTO dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await topicService.UpdateTopicAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // Silme (GET onay sayfası)
    public async Task<IActionResult> Delete(Guid id)
    {
        var topic = await topicService.GetTopicByIdAsync(id);
        if (topic == null) return NotFound();
        return View(topic);
    }

    // Silme (POST)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await topicService.DeleteTopicAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
