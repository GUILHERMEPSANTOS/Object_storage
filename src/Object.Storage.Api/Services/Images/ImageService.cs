using Object.Storage.Api.Controllers;
using Object.Storage.Infra.Storage;
using Object.Storage.Infra.Storage.Minio;

namespace Object.Storage.Api.Services.Images
{

    public interface IImageService
    {   
        Task UploadImageAsync(FileUploadRequest fileUpload);
    }

    public class ImageService : IImageService
    {
        private readonly IStorageProvider _storageProvider;

        public ImageService(IStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }

        public async Task UploadImageAsync(FileUploadRequest fileUpload)
        {
            var uploadFile = new UploadFile(fileUpload.File, fileUpload.SubPath);
           
           await  _storageProvider.UploadFileAsync(
                uploadFile,
                BucketTopology.Images                
            );           
        }
    }
}
