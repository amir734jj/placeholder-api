using System.Drawing;
using System.Threading.Tasks;
using Logic.Enums;

namespace Logic.Interfaces
{
    public interface IPlaceholderLogic
    {
        Task<(byte[] file, string contentType)> Resolve(
            int height,
            int width,
            KnownColor color,
            string text,
            KnownImageFormat format,
            string cacheKey);
    }
}