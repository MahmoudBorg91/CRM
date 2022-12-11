using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace GSI_Internal.Repositry.FileUploadServicesRepo
{
    public interface IBufferedFileUploadService
    {
        Task<bool> UploadFile(MultipartReader reader, MultipartSection section, string UploadfileName,string UploadfilePath);
    }
  
}
