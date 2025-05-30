
using Minio;
using Minio.DataModel.Args;

namespace Object.Storage.Infra.Storage.Minio
{
    public class MinioStorageProvider : IStorageProvider
    {
        private readonly IMinioClient _minioClient;

        public MinioStorageProvider(IMinioClient minioClient)
        {
            _minioClient = minioClient;
        }

        public async Task UploadFileAsync(UploadFile uploadFile, string bucketName)
        {
            if(!BucketTopology.IsValidBucketName(bucketName))
                throw new Exception($"Bucket name '{bucketName}' is not valid. Valid names are: {string.Join(", ", BucketTopology.ValidBucketNames)}.");

            await CreateBucketIfNotExistsAsync(bucketName);

            if(!uploadFile.IsValid()) 
                   throw new Exception("file is no valid");

            if(!BucketTopology.IsValidContentType(bucketName, uploadFile.ContentType))
                throw new Exception($"Content type '{uploadFile.ContentType}' is not valid for bucket '{bucketName}'. Valid content types are: {string.Join(", ", BucketTopology.BucketsValidContentType[bucketName])}.");

            using var stream = uploadFile.File.OpenReadStream();

            var putObjectArgs = new PutObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(uploadFile.ObjectName)                    
                    .WithStreamData(stream)
                    .WithObjectSize(uploadFile.Length)
                    .WithContentType(uploadFile.ContentType);

            await _minioClient.PutObjectAsync(putObjectArgs);
        }

        public async Task CreateBucketIfNotExistsAsync(string bucketName)
        {
            var exists = await BucketExists(bucketName);

            if (exists) return;

            var mbArgs = new MakeBucketArgs()
                .WithBucket(bucketName);

            await _minioClient.MakeBucketAsync(mbArgs);
        }

        public async Task<bool> BucketExists(string bucketName)
        {
            var beArgs = new BucketExistsArgs()
                .WithBucket(bucketName);

            return await _minioClient.BucketExistsAsync(beArgs);
        }
    }
}
