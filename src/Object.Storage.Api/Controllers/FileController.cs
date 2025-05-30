using Microsoft.AspNetCore.Mvc;
using Object.Storage.Api.Services.Images;

namespace Object.Storage.Api.Controllers
{
    [ApiController]
    [Route("v1/file")]
    public class FileController : ControllerBase
    {
        private readonly IImageService _imageService;

        public FileController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<ActionResult> UploadToMinio([FromForm] FileUploadRequest file)
        {
            await _imageService.UploadImageAsync(file);

            return Ok();
        }
    }
}
