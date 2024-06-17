using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Opticron;

[Route("/offer")]
public class OfferController : Controller
{
    private readonly IContentRepository _contentRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public OfferController(IContentRepository contentRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        this._contentRepository = contentRepository ?? throw new ArgumentNullException(nameof(contentRepository));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this._webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

    var offer = await _contentRepository.GetOfferAsync(id.Value);
        if (offer == null)
        {
            return NotFound();
        }
        var directoryContents = new PhysicalFileProvider(_webHostEnvironment.WebRootPath).GetDirectoryContents("images/offers");
        var model = new EditOfferViewModel
        {
            Offer = offer,
            DirectoryContents = directoryContents
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Offer offer)
    {
        var offerItemToChange = await _contentRepository.GetOfferAsync(offer.Id);
        if (offerItemToChange == null)
        {
            return NotFound();
        }
        offerItemToChange.Title = offer.Title;
        offerItemToChange.Description = offer.Description;
        offerItemToChange.ImageUrl = offer.ImageUrl;

        await _contentRepository.UpdateOffer(offerItemToChange);

        return RedirectToAction(controllerName: "CMS", actionName: "Index");
    }
}
