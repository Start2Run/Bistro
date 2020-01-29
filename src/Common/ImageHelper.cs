using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Common
{
    public static class ImageHelper
    {
        public static byte[] ConvertImageToByte(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        public static BitmapImage ImageFromByteArray(byte[] arrayOfByte)
        {
            var image = new BitmapImage();
            using (var mem = new MemoryStream(arrayOfByte))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
