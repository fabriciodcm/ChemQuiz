using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public static class Constants
    {
        static readonly string APIUrl = "https://chemquizapi.azurewebsites.net/api/";
        public static string URL
        {
            get {
                return APIUrl;
            }
        }
    }
}
