using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuiz.API.Models
{
    public class AppUser
    {
        [Key]
        public long UserId { get; set; }
        public string AuthId { get; set; }
        public long Coins { get; set; }
    }
}
