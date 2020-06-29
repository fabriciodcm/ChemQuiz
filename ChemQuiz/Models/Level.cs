using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public class Level
    {
        public int LevelNumber { get; set; }

        public bool isFinished { get; set; }

        public string LevelIcon { get; set; }

        public string LevelDescription { get; set; }

        public string LevelLesson { get; set; }
        public List<Quiz> LevelQuizList { get; set; }
        public Game LevelGame { get; set; }
    }
}
