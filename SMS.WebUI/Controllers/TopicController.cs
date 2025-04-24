using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.Topic;
using SMS.WebUI.Services.Module;
using SMS.WebUI.Services.Topic;

namespace SMS.WebUI.Controllers;

public class TopicController(ITopicService topicService, IModuleService moduleService) : Controller
{
    public async Task<IActionResult> Index(int? moduleId)
    {
        // Modülleri çekiyoruz
        var modules = await moduleService.GetAllModuleAsync();
        ViewBag.Modules = modules;

        // Eğer moduleId parametresi varsa, o id'yi kullanıyoruz; yoksa ilk modül id'sini kullanıyoruz
        var selectedModuleId = moduleId ?? modules.FirstOrDefault()?.Id ?? 0;

        // Modül ID'sine göre topic verilerini çekiyoruz
        var topics = await topicService.GetAllTopicsByModuleIdAsync(selectedModuleId);

        // View'e veri gönderiyoruz
        return View(topics);
    }


    public async Task<IActionResult> GetTopicsByModule(int moduleId)
    {
        // Modül ID'sine göre topic verilerini çekiyoruz
        var topics = await topicService.GetAllTopicsByModuleIdAsync(moduleId);

        // PartialView olarak veri döndürüyoruz
        return PartialView("_TopicListPartial", topics);
    }



    // Detay
    public async Task<IActionResult> Detail(int id)
    {
        var topic = await topicService.GetTopicByIdAsync(id);
        if (topic == null) return NotFound();
        return View(topic);
    }

    // Oluşturma (GET)
    public async Task<IActionResult> Create()
    {
        var modules = await moduleService.GetAllModuleAsync(); // bu servisi senin eklemen gerekebilir
        ViewBag.Modules = modules;

        return View();
    }

    // Oluşturma (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TopicCreateDto dto)
    {
        await topicService.CreateTopicAsync(dto);
        return RedirectToAction("Index", "Topic");
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