using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Classes
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(TimeSpan timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }

        public PracticalExam(TimeSpan timeOfExam, Question[] questions) : base(timeOfExam, questions)
        {
        }

        public override object Clone()
        {
            var clonedQuestions = new Question[Questions.Length];
            for (int i = 0; i < Questions.Length; i++)
                clonedQuestions[i] = (Question)Questions[i].Clone();
            return new PracticalExam(TimeOfExam, clonedQuestions);
        }

        public void ShowRightAnswers()
        {
            Console.WriteLine("----- Right answers (exam finished) -----");
            for (int i = 0; i < Questions.Length; i++)
            {
                var question = Questions[i];
                bool correct = question.IsCorrect();
                Console.WriteLine($"{question.header} -> Your answer: {question.studentAnswer} | Correct answer: {question.rightAnswer} | {(correct ? "Correct" : "Incorrect")}");
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine("===== Practical Exam =====");
            Console.WriteLine(this);
            Console.WriteLine();

            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].AnswerQuestion();
                Console.WriteLine();
            }
        }
    }
}
