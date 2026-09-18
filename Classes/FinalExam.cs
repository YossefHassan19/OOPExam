using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Classes
{
    internal class FinalExam : Exam
    {
        public FinalExam(TimeSpan timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }
        public FinalExam(TimeSpan timeOfExam, Question[] questions) : base(timeOfExam, questions)
        {
        }


        public override object Clone()
        {
            var clonedQuestions = new Question[Questions.Length];
            for (int i = 0; i < Questions.Length; i++)
                clonedQuestions[i] = (Question)Questions[i].Clone();
            return new FinalExam(TimeOfExam, clonedQuestions);
        }

        public override void ShowExam()
        {
            Console.WriteLine("===== Final Exam =====");
            Console.WriteLine(this);
            Console.WriteLine();

            int earnedMarks = 0;
            int totalMarks = 0;
            for (int i = 0; i < Questions.Length; i++)
            {
                var question = Questions[i];
                question.AnswerQuestion();

                bool correct = question.IsCorrect();
                Console.WriteLine(correct
                    ? "   -> Correct!"
                    : $"   -> Incorrect. Correct answer: {question.rightAnswer}");
                Console.WriteLine();

                totalMarks += question.mark;
                if (correct) earnedMarks += question.mark;
            }

            Console.WriteLine($"Grade: {earnedMarks} / {totalMarks}");
        }
    }
}
