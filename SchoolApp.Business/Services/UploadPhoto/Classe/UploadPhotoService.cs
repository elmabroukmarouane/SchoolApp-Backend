using Microsoft.AspNetCore.Http;
using SchoolApp.Business.Services.UploadPhoto.Interface;

namespace SchoolApp.Business.Services.UploadPhoto.Classe;
public class UploadPhotoService : IUploadPhotoService
{
    public async Task UploadPhotoAsAsync(IList<IFormFile>? photos = null, string pathRootApp = "")
    {
        foreach (var photo in photos)
        {
            if (photo.Length > 0)
            {
                await CopyPhotoAsAsync(photo, pathRootApp);
            }
        }
    }

    private async Task CopyPhotoAsAsync(IFormFile photo, string pathRootApp)
    {
        var directoryPath = Path.Combine(pathRootApp, "Images");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        var fullPathPhoto = Path.Combine(directoryPath, photo.FileName); //  + "_" + DateTimeOffset.UtcNow.ToString("ddMMyyyy")ss
        using (var stream = System.IO.File.Create(fullPathPhoto))
        {
            await photo.CopyToAsync(stream);
        }
    }
}