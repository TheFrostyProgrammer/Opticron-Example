using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Opticron.Models;

namespace Opticron.Controllers;

[Controller]
[Route("/")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IContentRepository _contentRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HomeController(ILogger<HomeController> logger, IContentRepository contentRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        this._contentRepository = contentRepository ?? throw new ArgumentNullException(nameof(contentRepository));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this._webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
    }

    public async Task<IActionResult> Index()
    {
        var News = await _contentRepository.GetAllNewsAsync();
        var Offers = await _contentRepository.GetAllOffersAsync();
        var bannerDirectory = new PhysicalFileProvider(_webHostEnvironment.WebRootPath).GetDirectoryContents("images/banners");
        var model = new IndexViewModel
        {
            News = News,
            Offers = Offers,
            BannerDirectoryContents = bannerDirectory
        };
        return View(model);
    }
    [Route("/Privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [Route("/Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
