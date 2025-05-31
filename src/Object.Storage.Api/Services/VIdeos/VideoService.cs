using Object.Storage.Api.Controllers;
using Object.Storage.Infra.Storage;
using Object.Storage.Infra.Storage.Minio;

namespace Object.Storage.Api.Services.VIdeos
{
    public class VideoService(IStorageProvider storageProvider) : IVideoService
    {
        public async Task UploadAsync(FileUploadRequest fileUpload)
        {
            var uploadFile = new UploadFile(fileUpload.File, fileUpload.SubPath);

            await storageProvider.UploadFileAsync(
                 uploadFile,
                 BucketTopology.Videos
             );
        }
    }
}
