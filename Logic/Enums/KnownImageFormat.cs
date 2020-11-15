using System.Drawing.Imaging;

namespace Logic.Enums
{
    public enum KnownImageFormat
    {
        Png, Jpeg, Bmp, Gif, Tiff, Wmf, Emf, Icon, Exif
    }
    
    public static class KnownImageFormatExtensions {

        public static ImageFormat ToImageFormat(this KnownImageFormat knownImageFormat)
        {
            return knownImageFormat switch
            {
                KnownImageFormat.Png => ImageFormat.Png,
                KnownImageFormat.Jpeg => ImageFormat.Jpeg,
                KnownImageFormat.Bmp => ImageFormat.Bmp,
                KnownImageFormat.Gif => ImageFormat.Gif,
                KnownImageFormat.Tiff => ImageFormat.Tiff,
                KnownImageFormat.Wmf => ImageFormat.Wmf,
                KnownImageFormat.Emf => ImageFormat.Emf,
                KnownImageFormat.Icon => ImageFormat.Icon,
                KnownImageFormat.Exif => ImageFormat.Exif,
                _ => ImageFormat.Png
            };
        }

        public static string ToContentType(this KnownImageFormat knownImageFormat)
        {
            return $"image/{knownImageFormat.ToString().ToLower()}";
        }
    }
}