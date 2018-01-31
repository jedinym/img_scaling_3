using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace img_scaling_3
{
    static class ByteImage
    {
        static public byte[] GetBytesFromImage(Bitmap _bitmap)
        {
            MemoryStream ms = new MemoryStream();
            _bitmap.Save(ms, ImageFormat.Bmp);
            _bitmap.Dispose();
            return ms.ToArray();
        }
        static public byte[] GetBytesFromFilepath(string _filepath)
        {
            Bitmap bitmap = null;
            MemoryStream ms = new MemoryStream();
            try
            {
                bitmap = new Bitmap(_filepath);
                bitmap.Save(ms, ImageFormat.Bmp);
                bitmap.Dispose();

                return ms.ToArray();
            }
            catch (ArgumentException)
            {
                return null;
            }
            finally
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
            }
        }
        static public Bitmap GetImageFromBytes(byte[] _imageBytes)
        {
            MemoryStream ms = new MemoryStream(_imageBytes);
            Image image = Image.FromStream(ms);           
            image = Image.FromStream(ms);
            Bitmap returnBitmap = new Bitmap(image);
            return returnBitmap;
        }
    }
}
