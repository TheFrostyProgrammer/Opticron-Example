using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Opticron;

[Route("/manage")]
public class CMSController : Controller
{
    private readonly IContentRepository _contentRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CMSController(IContentRepository contentRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        this._contentRepository = contentRepository ?? throw new ArgumentNullException(nameof(contentRepository));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this._webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
    }

    public async Task<IActionResult> Index()
    {

        IndexViewModel model = new IndexViewModel();
        model.News = await _contentRepository.GetAllNewsAsync();
        model.Offers = await _contentRepository.GetAllOffersAsync();

        // search directories for images
        model.BannerDirectoryContents = new PhysicalFileProvider(_webHostEnvironment.WebRootPath).GetDirectoryContents("images/banners");   
        //model.DirectoryContents = imageDirectory;
        return View(model);
    }
}
