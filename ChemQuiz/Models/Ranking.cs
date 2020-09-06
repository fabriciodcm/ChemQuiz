using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public class Ranking
    {
        public Rank Rank { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }

        public string Medal
        {
            get
            {
                switch ((int)Rank) {
                    case 1:
                        return "goldmedal.png";
                    case 2:
                        return "silvermedal.png";
                    case 3:
                        return "bronzemedal.png";
                    default:
                        return "";
                }
            }
        }
    }
}
