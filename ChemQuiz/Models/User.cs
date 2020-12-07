using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public class User
    {
        public string Id { get; set; }
        public long Coins { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public Avatar Avatar { get; set; }
        [JsonIgnore]
        public List<Avatar> PurchasedAvatars { get; set; }
    }
}
