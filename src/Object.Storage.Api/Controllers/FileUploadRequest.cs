namespace Object.Storage.Api.Controllers
{
    public class FileUploadRequest
    {
        public IFormFile File { get; set; }
        public string SubPath { get; set; }
    }
}
