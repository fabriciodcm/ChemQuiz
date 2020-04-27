﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Play
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
