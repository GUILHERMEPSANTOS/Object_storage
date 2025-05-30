using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Object.Storage.Infra.Storage;

namespace Object.Storage.Api.Controllers
{
    [ApiController]
    [Route("v1/file")]
    public class FileController : ControllerBase
    {
        private readonly IStorageProvider storageProvider;

        public FileController(IStorageProvider storageProvider)
        {
            this.storageProvider = storageProvider;
        }

        [HttpPost]
        public async Task<ActionResult> UploadToMinio(IFormFile file)
        {
            
        }
    }
}
