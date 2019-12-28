using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace twoja_manufaktura.Infrastructure
{
    public class AppConfig
    {
        private static string _genreIconsFolderRelative = ConfigurationManager.AppSettings["GenreIconsFolder"];
        public static string GenreIconsFolderRelative
        {
            get
            {
                return _genreIconsFolderRelative;
            }
        }

        private static string _imagesFolderRelative = ConfigurationManager.AppSettings["ImagesFolder"];
        public static string imagesFolderRelative
        {
            get
            {
                return _imagesFolderRelative;
            }
        }
        
    }
}