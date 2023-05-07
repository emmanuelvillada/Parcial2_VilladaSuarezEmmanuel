namespace Parcial3.Helpers
{
	public interface IAzureBlobHelper
	{
		Task<Guid> UploadAzureBlobAsync(IFormFile file, string containerName);

		Task<Guid> UploadAzureBlobAsync(string image, string containerName);

		Task DeleteAzureBlobAsync(Guid id, string containerName);
	}
}
