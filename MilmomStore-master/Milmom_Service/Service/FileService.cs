using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Milmom_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class FileService : IFileService
    {
        /*private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }*/

        /*public async Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtentions)
        {
            if (imageFile == null)
            {
                throw new ArgumentNullException(nameof(imageFile));
            }

            var contentPath = Directory.GetCurrentDirectory();
            var path = Path.Combine(contentPath, "Uploads");
            // path = "c://projects/ImageManipulation.Ap/uploads" ,not exactly, but something like that

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Check the allowed extenstions
            var ext = Path.GetExtension(imageFile.FileName);
            if (!allowedFileExtentions.Contains(ext))
            {
                throw new ArgumentException($"Only {string.Join(",", allowedFileExtentions)} are allowed.");
            }

            // generate a unique filename
            var fileName = $"{Guid.NewGuid().ToString()} {ext}";
            var fileNameWithPath = Path.Combine(path, fileName);
            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await imageFile.CopyToAsync(stream);
            return fileName;
        }
        public void DeleteFile(string fileNameWithExtention)
        {
            if (string.IsNullOrEmpty(fileNameWithExtention))
            {
                throw new ArgumentNullException(nameof(fileNameWithExtention));
            }
            var contentPath = Directory.GetCurrentDirectory();
            var path = Path.Combine(contentPath, $"Uploads", fileNameWithExtention);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Invalid file path");
            }
            File.Delete(path);
        }*/

        public string ConvertToString(IFormFile file)
        {
            //extention
            List<string> validExtentions = new List<string>() { ".jpg", ".png", ".gif" };
            string extention = Path.GetExtension(file.FileName);
            if (!validExtentions.Contains(extention))
            {
                return $"Extention is not valid({string.Join(',', validExtentions)})";
            }
            //file size
            long size = file.Length;
            if (size > (10 * 1024 * 1024))
            {
                return "Maximum Size can be 10Mb";
            }
            //name changing
            string fileName = Guid.NewGuid().ToString() + extention;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream stream = new FileStream(path + fileName, FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }

        /*public byte[] ConvertToByteArray(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            // Extension validation
            List<string> validExtensions = new List<string>() { ".jpg", ".png", ".gif" };
            string extension = Path.GetExtension(file.FileName);
            if (!validExtensions.Contains(extension))
            {
                throw new ArgumentException($"Extension is not valid ({string.Join(',', validExtensions)})");
            }

            // File size validation (10 MB limit)
            long size = file.Length;
            if (size > (10 * 1024 * 1024))
            {
                throw new ArgumentException("Maximum file size can be 10 MB");
            }

            // Read file contents into byte array
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }*/


    }
}
