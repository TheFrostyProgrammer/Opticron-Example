using System.ComponentModel.DataAnnotations;

namespace Opticron;

public class SingleFileUploadModel
{
    [Required]
    public IFormFile FormFile { get; set; }
    [Required]
    public string Folder { get; set; }
}
