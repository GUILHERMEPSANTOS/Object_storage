using Object.Storage.Api.Controllers;

namespace Object.Storage.Api.Services.VIdeos
{
    public interface IVideoService
    {
        Task UploadAsync(FileUploadRequest fileUpload);
    }
}
