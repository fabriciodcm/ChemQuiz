using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public static class Session
    {
        public static User loggedUser = null;
        public static DateTime? sessionExpiretion = null;
        public static string accessToken = null;
    }
}
