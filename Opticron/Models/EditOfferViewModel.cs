using Microsoft.Extensions.FileProviders;

namespace Opticron;

public class EditOfferViewModel
{
    public Offer Offer { get; set; }
    public IDirectoryContents DirectoryContents { get; set; }
}
