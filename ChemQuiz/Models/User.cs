using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string AuthId { get; set; }
        public long Coins { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public string FamilyName { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        [JsonIgnore]
        public Avatar Avatar { get; set; }
        [JsonIgnore]
        public List<Avatar> PurchasedAvatars { get; set; }
    }
}
