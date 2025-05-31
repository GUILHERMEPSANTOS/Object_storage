using Object.Storage.Api.Controllers;

namespace Object.Storage.Api.Services.Images
{
    public interface IImageService
    {
        Task UploadAsync(FileUploadRequest fileUpload);
    }
}
