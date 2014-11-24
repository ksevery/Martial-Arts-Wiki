using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.UI.Xaml.Media.Imaging;

namespace MartialArtsWiki
{
    public static class Extensions
    {
        public static byte[] ToByteArray (this BitmapImage bitmapImage)
        {
            byte[] buffer = null;
            using (MemoryStream ms = new MemoryStream())
            {
                WriteableBitmap wb = new WriteableBitmap(bitmapImage.PixelWidth, bitmapImage.PixelHeight);
                Stream s1 = wb.PixelBuffer.AsStream();
                s1.CopyTo(ms);

                buffer = ms.ToArray();
            }

            return buffer;
        }

        public static void AddRange<T> (this IList<T> collection, IEnumerable<T> values)
        {
            foreach (var item in values)
            {
                collection.Add(item);
            }
        }
    }
}
