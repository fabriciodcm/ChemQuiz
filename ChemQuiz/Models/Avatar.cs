using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChemQuiz.Models
{
    public class Avatar
    {
        public int IdAvatar { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string FormattedPrice
        {
            get
            {
                return "$" + Price;
            }
        }
        public ImageSource Image
        {
            get
            {
                return ImageSource.FromResource("ChemQuiz.Resources.Avatars." + Name);
            }
        }
    }
}
