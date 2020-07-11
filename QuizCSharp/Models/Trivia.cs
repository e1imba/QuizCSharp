using System;
using System.Collections.Generic;
using System.Text;

namespace QuizCSharp.Models
{
    class Trivia
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
    }
}
