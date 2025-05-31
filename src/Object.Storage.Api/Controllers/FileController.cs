using Microsoft.AspNetCore.Mvc;
using Object.Storage.Api.Services.Images;
using Object.Storage.Api.Services.VIdeos;

namespace Object.Storage.Api.Controllers
{
    [ApiController]
    [Route("v1/file")]
    public class FileController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IVideoService _videoService;

        public FileController(IImageService imageService, IVideoService videoService)
        {
            _imageService = imageService;
            _videoService = videoService;
        }

        [HttpPost("image")]
        public async Task<ActionResult> UploadImage([FromForm] FileUploadRequest file)
        {
            await _imageService.UploadAsync(file);

            return Ok();
        }

        [HttpPost("video")]
        public async Task<ActionResult> UploadVideo([FromForm] FileUploadRequest file)
        {
            await _videoService.UploadAsync(file);

            return Ok();
        }
    }
}
