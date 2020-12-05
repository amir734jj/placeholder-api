using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Logic.Enums;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Controllers
{
    [Route("[controller]")]
    public class PlaceholderController : Controller
    {
        private readonly IPlaceholderLogic _placeholderLogic;

        public PlaceholderController(IPlaceholderLogic placeholderLogic)
        {
            _placeholderLogic = placeholderLogic;
        }

        [Route("")]
        [HttpGet]
        [SwaggerOperation("CreatePlaceholderImage")]
        [ProducesResponseType(typeof(File), 200)]
        public async Task<IActionResult> Index(
            int height = 100,
            int width = 100,
            KnownColor color = KnownColor.LightGray,
            string text = "thumbnail",
            KnownImageFormat format = KnownImageFormat.Png
        )
        {
            var request = Request.QueryString.ToUriComponent();

            var cacheKey = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(request)));

            var (data, contentType, name) =
                await _placeholderLogic.Resolve(height, width, color, text, format, cacheKey);

            return File(data, contentType, name);
        }
    }
}