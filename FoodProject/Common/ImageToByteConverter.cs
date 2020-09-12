using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Common
{
    public class ImageToByteConverter
    {
        internal static byte[] Convert(string userImage)
        {
            FileStream fileStream = new FileStream(userImage, FileMode.Open);
            byte[] image = new byte[fileStream.Length];
            fileStream.Read(image, 0, (int)fileStream.Length);
            fileStream.Close();
            return image;
        }
    }
}
