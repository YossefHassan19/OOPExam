using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Classes
{
    internal abstract class Question : ICloneable, IComparable<Question>
    {
        public string header { get; set; }
        public string body { get; set; }
        public int mark { get; set; }
        public Answer[] answerList { get; set; }
        public Answer rightAnswer { get; set; }
        public Answer? studentAnswer { get; set; }

        protected Question(string header, string body, int mark)
        {
            this.header = header;
            this.body = body;
            this.mark = mark;
            answerList = new Answer[0];
        }

        public abstract object Clone();

        public abstract void showQuestion();

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return mark.CompareTo(other.mark);
        }
        public override string ToString()
        {
            return $"{header} [{mark} mark(s)]: {body}";
        }

        protected string AnswersToString()
        {
            var sb = new StringBuilder();
            foreach (var answer in answerList)
                sb.AppendLine("   " + answer);
            return sb.ToString();
        }

        public void AnswerQuestion()
        {
            showQuestion();
            while (true)
            {
                Console.Write("  Your answer (Id): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int id))
                {
                    Answer? chosen = FindAnswerById(answerList, id);
                    if (chosen != null)
                    {
                        studentAnswer = chosen;
                        return;
                    }
                }
                Console.WriteLine("  Invalid Id, please try again.");
            }
        }

        public bool IsCorrect()
        {
            return studentAnswer != null && rightAnswer != null
                && studentAnswer.answerId == rightAnswer.answerId;
        }

        private static Answer? FindAnswerById(Answer[] answers, int id)
        {
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i].answerId == id)
                    return answers[i];
            }
            return null;
        }

    }
}
