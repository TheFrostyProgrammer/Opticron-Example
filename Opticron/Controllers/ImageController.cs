using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Opticron;

[Route("/image")]
public class ImageController : Controller
{
    private readonly IContentRepository _contentRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;

    // manage the image folder by adding and deleting images

    public ImageController(IContentRepository contentRepository, IMapper mapper,
        IWebHostEnvironment webHostEnvironment)
    {
        this._contentRepository = contentRepository ?? throw new ArgumentNullException(nameof(contentRepository));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this._webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
    }

    public async Task<IActionResult> AddImage()
    {
        return View(new SingleFileUploadModel());
    }

    [HttpPost]
    public async Task<IActionResult> AddImage(SingleFileUploadModel model)
    {
        if (model.FormFile == null)
        {
            return RedirectToAction(controllerName: "CMS", actionName: "Index");
        }
        var image = model.FormFile;

        var uniqueFileName = GetUniqueFileName(model.FormFile.FileName);
        var folderName = Path.Combine("images", model.Folder);
        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
        var filePath = Path.Combine(uploadPath, uniqueFileName);
        model.FormFile.CopyTo(new FileStream(filePath, FileMode.Create));
        return RedirectToAction(controllerName: "CMS", actionName: "Index");
    }

    private string GetUniqueFileName(string FileName)
    {
        FileName = Path.GetFileName(FileName);
        return Path.GetFileNameWithoutExtension(FileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0,4)
                + Path.GetExtension(FileName);
    }
        
}
