using Object.Storage.Infra.Storage;

namespace Object.Storage.Api.Services.Images
{

    public interface IImageService
    {   
        Task UploadImageAsync(IFormFile file);
    }

    public class ImageService : IImageService
    {
        private readonly IStorageProvider _storageProvider;

        public ImageService(IStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }

        public Task UploadImageAsync(IFormFile file)
        {
            //Implementtion of image upload logic
            return Task.CompletedTask;
        }
    }
}
