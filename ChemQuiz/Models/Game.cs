using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public class Game
    {
        public Category GameCategory { get; set; }
        public String GameName { get; set; }
        public String GameDescription { get; set; }
        public List<Level> Levels { get; set; }
    }
}
