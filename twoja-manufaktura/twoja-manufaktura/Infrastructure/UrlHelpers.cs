using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace twoja_manufaktura.Infrastructure
{
    public static class UrlHelpers
    {
        public static string GenreIconPath(this UrlHelper helper, string genreIconFilename)
        {
            var genreIconFolder = AppConfig.GenreIconsFolderRelative;
            var path = Path.Combine(genreIconFolder, genreIconFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
        public static string ProductImagePath(this UrlHelper helper, string imageFilename)
        {
            var imageFolder = AppConfig.imagesFolderRelative;
            var path = Path.Combine(imageFolder, imageFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}