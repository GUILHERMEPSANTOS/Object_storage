using Microsoft.AspNetCore.Http;

namespace Object.Storage.Infra.Storage
{
    public class UploadFile
    {
        public IFormFile File { get; private set; }        
        public string FileName => File?.FileName ?? string.Empty;
        public string ContentType => File?.ContentType ?? string.Empty;
        public long Length => File?.Length ?? 0;       
               
        public UploadFile(IFormFile file)
        {
            File = file;
        }              
        
        public bool IsValid()
        {
            return File != null && File.Length > 0 && !string.IsNullOrEmpty(File.FileName);
        }   
    }
}
