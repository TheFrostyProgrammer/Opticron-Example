using Microsoft.Extensions.FileProviders;

namespace Opticron;

public class EditNewsViewModel
{
    public News News { get; set; }
    public IDirectoryContents DirectoryContents { get; set; }

}
