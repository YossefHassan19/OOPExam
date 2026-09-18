using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Classes
{
    internal class Answer : ICloneable, IComparable<Answer>
    {
        public int answerId { get; set; }
        public string answerText { get; set; }

        public Answer(int answerId, string answerText)
        {
            this.answerId = answerId;
            this.answerText = answerText;

        }
        public object Clone()
        {
            return new Answer(this.answerId, this.answerText);
        }

        public override string ToString()
        {
            return $"({answerId}) {answerText}";
        }

        public int CompareTo(Answer? other)
        {
            if (other == null) return 1;
            return answerId.CompareTo(other.answerId);
        }
    }

}
