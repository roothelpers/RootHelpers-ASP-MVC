using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace RootHelpers
{
    public static class HtmlHelpers
    {
        public static MD5 md5 = MD5.Create();

        public static IHtmlString HtmlImageThumbnail(string imagePath, int width, int height, string alt = null, string @class = null)
        {
            return HtmlImageThumbnail(imagePath, new Size(width, height), alt, @class);
        }

        /// <summary>
        /// Get the Display Name for a model.
        /// </summary>
        /// <typeparam name="TModel">The model's Type</typeparam>
        /// <param name="helper">The HTML Helper for the model.</param>
        /// <returns>Returns the DisplayName for the model.</returns>
        /// <remarks>
        /// Use the DisplayNameAttribute on your model to assign the name to be returned.
        /// Unfortunately we can not use the better/newer DisplayAttribute to specify the name
        /// because Microsoft marked it to only be used on properties, not on classes.
        ///
        /// Use: @Html.DisplayNameFor()
        /// </remarks>
        ///
        public static IHtmlString HtmlImageThumbnail(string imagePath, Size size, string alt = null, string @class = null)
        {
            var cacheFolder = "/ImageCache/";
            var context = HttpContext.Current;
            var path = context.Server.MapPath(imagePath);
            var hashName = string.Concat(GetMd5Hash(string.Concat(path.Trim().ToLower(), "-", size.Width, "x", size.Height)), Path.GetExtension(imagePath).ToLower());
            var cachedImagePath = context.Server.MapPath(Path.Combine(cacheFolder, hashName));
            if (!File.Exists(cachedImagePath) && File.Exists(path))
            {
                using (Bitmap bmp = new Bitmap(path))
                {
                    bmp.GetThumbnailImage(size.Width, size.Height, null, IntPtr.Zero).Save(cachedImagePath);
                }
            }

            var src = string.Concat(cacheFolder, hashName);

            XElement imgTag = new XElement("img", new XAttribute("src", src), new XAttribute("alt", !String.IsNullOrWhiteSpace(alt) ? alt : string.Empty), new XAttribute("class", !String.IsNullOrWhiteSpace(@class) ? @class : string.Empty));

            return new HtmlString(imgTag.ToString());
        }

        private static string GetMd5Hash(string input)
        {
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}