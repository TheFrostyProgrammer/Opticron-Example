using Microsoft.Extensions.FileProviders;

namespace Opticron;

public class IndexViewModel
{
    public IEnumerable<News?> News { get; set; }
    public IEnumerable<Offer?> Offers { get; set; }
    public IEnumerable<Category?> Categories { get; set; }
    public IEnumerable<Carousel?> Carousels { get; set; }
    public IDirectoryContents DirectoryContents { get; set; }
    public IDirectoryContents BannerDirectoryContents { get; set; }
}
