using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Utils
{
    public class FileUtils
    {
        public static string CreateFile(string folderPath, string folderName, IFormFile file)
        {
            var fileName = Guid.NewGuid() + file.FileName;
            var fullPaht = Path.Combine(folderPath, folderName, fileName);

            FileStream Stream = new FileStream(fullPaht, FileMode.Create);
            file.CopyTo(Stream);
            Stream.Close();
            return fileName;

        }
        public static void DeleteFile(string FullPath)
        {
            if (File.Exists(FullPath))
            {
                File.Delete(FullPath);
            }
        }
    }
}
