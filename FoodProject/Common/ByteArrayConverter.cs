using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Common
{
    public static class ByteArrayConverter
    {
        public async static Task<byte[]> ConvertImageToByteArrayAsync(List<IFormFile> userImage)
        {
            MemoryStream stream = new MemoryStream();
            foreach (var item in userImage)
            {
                await item.CopyToAsync(stream);
            }
            return stream.ToArray();
        }
    }
}
