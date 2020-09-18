using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChemQuiz.Models
{
    public class Avatar
    {
        public long AvatarId { get; set; }
        public string AvatarName { get; set; }
        public decimal AvatarPrice { get; set; }
        public string FormattedPrice
        {
            get
            {
                return "$" + AvatarPrice;
            }
        }
        public ImageSource Image
        {
            get
            {
                return ImageSource.FromResource("ChemQuiz.Resources.Avatars." + AvatarName);
            }
        }
    }
}
