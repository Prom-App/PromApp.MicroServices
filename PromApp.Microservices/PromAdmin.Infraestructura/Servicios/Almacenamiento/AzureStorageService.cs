using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PromAdmin.Core.Interfaces.Almacenamiento;
using PromAdmin.Core.Modelos.Options;

namespace PromAdmin.Infraestructura.Servicios.Almacenamiento;

public class AzureStorageService : IAzureStorageService
{
    private readonly AzureSettings _azureSettings;

    public AzureStorageService(IOptions<AzureSettings> azureSettings)
    {
        _azureSettings = azureSettings.Value;
    }

    public async Task<string> SaveFile(string container, string path, IFormFile file)
    {
        var client = new BlobContainerClient(_azureSettings.BlobConnString, container);

        await client.CreateIfNotExistsAsync();
        await client.SetAccessPolicyAsync(PublicAccessType.Blob);

        var extension = Path.GetExtension(file.FileName);
        var fileName = $"{path}/{Guid.NewGuid()}{extension}";
        var blob = client.GetBlobClient(fileName);

        await blob.UploadAsync(file.OpenReadStream());

        return blob.Uri.ToString();
    }

    public async Task<string> EditFile(string container, string path, IFormFile file, string route)
    {
        await RemoveFile(route, container);
        return await SaveFile(container, path, file);
    }

    public async Task RemoveFile(string route, string container)
    {
        if (string.IsNullOrEmpty(route))
        {
            return;
        }

        var client = new BlobContainerClient(_azureSettings.BlobConnString, container);

        await client.CreateIfNotExistsAsync();
        var file = Path.GetFileName(route);
        var blob = client.GetBlobClient(file);

        await blob.DeleteIfExistsAsync();
    }
}