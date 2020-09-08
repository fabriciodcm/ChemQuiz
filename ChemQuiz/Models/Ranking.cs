using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ChemQuiz.Models
{
    public class Ranking
    {
        public Rank Rank { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }

        public long coins { get; set; }
        public string Coins 
        {
            get { return "$" + coins; }
        }

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
