using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Parcial3.Helpers;

namespace Parcial3.Services
{
	public class AzureBlobHelper : IAzureBlobHelper
	{
		private readonly CloudBlobClient _cloudBlobClient; //Me permite acceder al almacenamiento de los Azure Blobs para aplicar cualquier operación CRUD.

		public AzureBlobHelper(IConfiguration configuration)
		{
			string keys = configuration["Blob:AzureStorage"];
			CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(keys);
			//Aquí con _cloudBlobClient ya tendré lo necesario para poder subir o bajar imágenes desde mi blob.
			_cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
		}

		public async Task<Guid> UploadAzureBlobAsync(IFormFile file, string containerName)
		{
			Stream stream = file.OpenReadStream(); // Arreglo en memoria de un archivo
			return await UploadAzureBlobAsync(stream, containerName);

		}

		public async Task<Guid> UploadAzureBlobAsync(string image, string containerName)
		{
			Stream stream = File.OpenRead(image);
			return await UploadAzureBlobAsync(stream, containerName);
		}

		private async Task<Guid> UploadAzureBlobAsync(Stream stream, string containerName)
		{
			Guid name = Guid.NewGuid();

			//Accedo al container
			CloudBlobContainer container = _cloudBlobClient.GetContainerReference(containerName);
			//Crea el blob con mi nombre
			CloudBlockBlob blockBlob = container.GetBlockBlobReference($"{name}");
			//Subo la foto al blob
			await blockBlob.UploadFromStreamAsync(stream);
			return name;
		}

		public async Task DeleteAzureBlobAsync(Guid id, string containerName)
		{
			CloudBlobContainer container = _cloudBlobClient.GetContainerReference(containerName);
			CloudBlockBlob blockBlob = container.GetBlockBlobReference($"{id}");
			await blockBlob.DeleteAsync();
		}
	}
}
