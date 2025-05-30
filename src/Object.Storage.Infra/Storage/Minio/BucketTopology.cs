using Object.Storage.Infra.Storage.MediaType;
using System.Net.Mime;

namespace Object.Storage.Infra.Storage.Minio
{
    public static class BucketTopology
    {
        public const string Videos = "videos";
        public const string Images = "images";

        public static readonly IReadOnlyCollection<string> ValidBucketNames = [Videos, Images];

        public static readonly IDictionary<string, string[]> BucketsValidContentType = new Dictionary<string, string[]>
        {
            [Videos] =
            [
                CustomMediaTypes.Mp4,                                
            ],
            [Images] =
            [
                MediaTypeNames.Image.Jpeg,
                MediaTypeNames.Image.Gif,
                MediaTypeNames.Image.Png,
            ]
        };

        public static bool IsValidBucketName(string bucketName)
        {
            return ValidBucketNames.Contains(bucketName);
        }

        public static bool IsValidContentType(string bucketName, string contentType)
        {
            return BucketsValidContentType.TryGetValue(bucketName, out var validTypes) &&
                   validTypes.Contains(contentType);
        }
    }
}


