using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using EasyCaching.Core;
using Logic.Enums;
using Logic.Interfaces;

namespace Logic
{
    public class PlaceholderLogic : IPlaceholderLogic
    {
        private readonly IEasyCachingProvider _cache;

        public PlaceholderLogic(IEasyCachingProviderFactory factory)
        {
            _cache = factory.GetCachingProvider("memory");
        }

        public async Task<(byte[] file, string contentType, string name)> Resolve(int height, int width, KnownColor color,
            string text,
            KnownImageFormat format, string cacheKey)
        {
            var contentType = format.ToContentType();
            var name = $"thumbnail.{contentType.Split('/')[1]}";
            var fontSize = Math.Max(height, width) / 10;

            var response = await _cache.GetAsync<byte[]>(cacheKey);

            if (response.HasValue)
            {
                return (response.Value, contentType, name);
            }

            var bitmap = new Bitmap(width, height);
            using var gfx = Graphics.FromImage(bitmap);
            using var brush = new SolidBrush(Color.FromKnownColor(color));
            using var arialFont = new Font("Arial", fontSize);
            
            gfx.FillRectangle(brush, 0, 0, width, height);

            var stringFormat = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            gfx.DrawString(text, arialFont, Brushes.Black, (float) (width / 2.0), (float) (height / 2.0), stringFormat);

            var stream = new MemoryStream();

            bitmap.Save(stream, format.ToImageFormat());

            var bytes = stream.ToArray();

            await _cache.SetAsync(cacheKey, bytes, TimeSpan.FromMinutes(5));

            return (bytes, contentType, name);
        }
    }
}