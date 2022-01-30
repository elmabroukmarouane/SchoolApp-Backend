using Microsoft.AspNetCore.Http;

namespace SchoolApp.Business.Services.UploadPhoto.Interface;
public interface IUploadPhotoService
{
    Task UploadPhotoAsAsync(IList<IFormFile>? photos = null, string pathRootApp = "");
}