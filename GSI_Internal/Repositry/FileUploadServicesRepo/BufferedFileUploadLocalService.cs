using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace GSI_Internal.Repositry.FileUploadServicesRepo
{
    public class BufferedFileUploadLocalService : IBufferedFileUploadService
    {
        public async Task<bool> UploadFile(MultipartReader reader, MultipartSection section, string uploadfileName, string uploadfilePath)
        {
            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(
                    section.ContentDisposition, out var contentDisposition
                );
                if (hasContentDispositionHeader)
                {
                    if (contentDisposition.DispositionType.Equals("form-data") &&
                        (!string.IsNullOrEmpty(contentDisposition.FileName.Value) ||
                         !string.IsNullOrEmpty(contentDisposition.FileNameStar.Value)))
                    {
                        string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, uploadfilePath));
                        byte[] fileArray;
                        using (var memoryStream = new MemoryStream())
                        {
                            await section.Body.CopyToAsync(memoryStream);
                            fileArray = memoryStream.ToArray();
                        }

                        if (contentDisposition.FileName.Value != null)
                        {
                            await using var fileStream =
                                System.IO.File.Create(Path.Combine(filePath, uploadfileName));
                            await fileStream.WriteAsync(fileArray);
                        }
                    }
                }
                section = await reader.ReadNextSectionAsync();
            }
            return true;
        }
    }

}
