using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Classes
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answers, int rightAnswerId) : base(header, body, mark)
        {
            answerList = answers;
            rightAnswer = answerList.FirstOrDefault(a => a.answerId == rightAnswerId);
        }

        public override void showQuestion()
        {
            Console.WriteLine(this);
            Console.Write(AnswersToString());
        }

        public override object Clone()
        {
            Answer[] clonedAnswers = answerList.Select(a => (Answer)a.Clone()).ToArray();
            int rightId = rightAnswer?.answerId ?? -1;
            return new MCQQuestion(header, body, mark, clonedAnswers, rightId);
        }

    }
}
