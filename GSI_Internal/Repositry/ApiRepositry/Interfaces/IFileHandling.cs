using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Repositry.ApiRepositry.Interfaces
{
    public interface IFileHandling
    {
        public Task<string> UploadFile(IFormFile file, string folder, string oldFilePAth = null);
        public Task<string> UploadFile(IFormFile file, string folder, string name, string oldFilePAth = null );
        public Task<string> UploadPhotoByte(byte[] imgBytes, string folderName, string oldFilePAth = null);

        public Task<string> UploadPhotoBase64(string stringFile, string folderName = "Student", string oldFilePAth = null);

        public string GetFile(string imgName);

        //public Task<FileResult>  DownloadFile(string fileName);

    }
}
