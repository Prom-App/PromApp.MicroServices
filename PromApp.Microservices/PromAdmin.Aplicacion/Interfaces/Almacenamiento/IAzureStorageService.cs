using Microsoft.AspNetCore.Http;

namespace PromAdmin.Core.Interfaces.Almacenamiento;

public interface IAzureStorageService
{
    Task<string> SaveFile(string container,string path, IFormFile file);
    Task<string> EditFile(string container,string path, IFormFile file, string route);
    Task RemoveFile(string route, string container);
}