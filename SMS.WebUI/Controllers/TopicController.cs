using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.Topic;
using SMS.WebUI.Services.Topic;

namespace SMS.WebUI.Controllers;

public class TopicController(ITopicService topicService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var topics = await topicService.GetAllTopicsAsync();
        return View(topics);
    }

    public async Task<IActionResult> GetAllTopicsWithModuleId()
    {
        var topics = await topicService.GetAllTopicsAsync();
        return View(topics);
    }

    // Detay
    public async Task<IActionResult> Detail(int id)
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
    public async Task<IActionResult> Create(TopicCreateDto dto)
    {
        
        await topicService.CreateTopicAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // Güncelleme (GET)
    public async Task<IActionResult> Edit(int id)
    {
        var topic = await topicService.GetTopicByIdAsync(id);
        if (topic == null) return NotFound();

        var updateDto = new TopicUpdateDto
        {
            Id = topic.Id,
            Title = topic.Title,
            ModuleId = topic.ModuleId,
            Status = topic.Status
        };

        return View(updateDto);
    }

    // Güncelleme (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TopicUpdateDto dto)
    {
        await topicService.UpdateTopicAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await topicService.DeleteTopicAsync(id);
        return RedirectToAction("Index", "Topic");
    }

    // [HttpPut]
    // public async Task<IActionResult> ChangeStatus(int id, [FromBody] bool status)
    // {
    //     await topicService.(id, status);
    //     return NoContent();
    // }
}