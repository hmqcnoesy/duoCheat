using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoCheat
{
    public class Answer
    {
        public bool? incorrect { get; set; } // some answers have an indicator of incorrect solution within
        public bool? correct { get; set; } // some answers have an indicator of correct solution within
        public string word { get; set; } // answer to "translate single word" questions
        public string value { get; set; } // answer provided to "translate sentence to english" questions
        public string Text { get { return value ?? word; } }
    }
}
