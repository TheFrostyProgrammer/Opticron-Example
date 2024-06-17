using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Opticron;
[Route("/news")]
public class NewsController : Controller
{
    private readonly IContentRepository _contentRepository;
    private readonly IMapper mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public NewsController(IContentRepository contentRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        this._contentRepository = contentRepository ?? throw new ArgumentNullException(nameof(contentRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this._webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        } 
        
        var result = await _contentRepository.GetNewsAsync((int)id!);

        if (result == null)
        {
            return NotFound();
        }

        var directoryContents = new PhysicalFileProvider(_webHostEnvironment.WebRootPath).GetDirectoryContents("images/news");
        var model = new EditNewsViewModel
        {
            News = result,
            DirectoryContents = directoryContents
        };
        // search for product
        // 
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(News news)
    {
        var newsItemToChange = await _contentRepository.GetNewsAsync(news.Id);
        newsItemToChange.Name = news.Name;
        newsItemToChange.Description = news.Description;
        newsItemToChange.ButtonName = news.ButtonName;
        newsItemToChange.ImageUrl = news.ImageUrl;

        await _contentRepository.UpdateNews(newsItemToChange);

        return RedirectToAction(controllerName: "CMS", actionName: "Index");
        
    }
}
