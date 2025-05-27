using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Object.Storage.Api.Controllers
{
    [ApiController]
    [Route("v1/file")]
    public class FileController : ControllerBase
    {
        private readonly IMinioClient minioClient;

        public FileController(IMinioClient minioClient)
        {
            this.minioClient = minioClient;
        }

        [HttpPost]
        public async Task<ActionResult> UploadToMinio(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Nenhum arquivo enviado.");

            var bucketName = "images";
            var objectName = file.Name;
            var contentType = $"application/{file.ContentType}";

            try
            {                
                var beArgs = new BucketExistsArgs()
                    .WithBucket(bucketName);

                bool found = await minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
                if (!found)
                {
                    var mbArgs = new MakeBucketArgs()
                        .WithBucket(bucketName);
                    await minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
                }

                using var stream = file.OpenReadStream();
                
                var putObjectArgs = new PutObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(objectName)
                    .WithStreamData(stream)
                    .WithObjectSize(file.Length)
                    .WithContentType(contentType);                
                await minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
 
             }
            catch (MinioException e)
            {
                Console.WriteLine("File Upload Error: {0}", e.Message);
            }
            return Ok();
        }
    }
}
