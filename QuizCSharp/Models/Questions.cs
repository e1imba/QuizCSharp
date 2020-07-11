using System;
using System.Collections.Generic;

namespace QuizCSharp.Models
{
    public partial class Questions
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
