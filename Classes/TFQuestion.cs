using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Classes
{
    internal class TFQuestion : Question
    {
        public TFQuestion(string header, string body, int mark, bool correctAnswerIsTrue) : base(header, body, mark)
        {
            answerList = new Answer[2]
            {
            new Answer(1, "True"),
            new Answer(2, "False")
            };
            rightAnswer = correctAnswerIsTrue ? answerList[0] : answerList[1];
        }
        public override object Clone()
        {
            bool isTrue = rightAnswer.answerId == 1;
            return new TFQuestion(header, body, mark, isTrue);
        }

        public override void showQuestion()
        {
            Console.WriteLine(this);
            Console.Write(AnswersToString());
        }
    }
}
