namespace Object.Storage.Infra.Storage
{
    public interface IStorageProvider
    {
        Task UploadFileAsync(UploadFile file, string bucketName);
    }
}
