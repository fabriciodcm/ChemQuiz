using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string AuthId { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public decimal Coins { get; set; }
        public Avatar Avatar { get; set; }
        public List<Avatar> PurchasedAvatars { get; set; }
    }
}
