using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DirectId.Api.Utils
{
    public static class FileReaderUtils
    {
        public static async Task<string> ReadFileAsync(this IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return string.Empty;
            }

            using var reader = new StreamReader(file.OpenReadStream());
            return await reader.ReadToEndAsync();
        }
    }
}
