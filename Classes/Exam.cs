using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Classes
{
    internal abstract class Exam : ICloneable
    {

        public TimeSpan TimeOfExam { get; set; }
        public Question[] Questions { get; set; }

        public int NumberOfQuestions => Questions?.Length ?? 0;
        private int nextIndex;

        protected Exam(TimeSpan timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            Questions = new Question[numberOfQuestions];
            nextIndex = 0;
        }

        protected Exam(TimeSpan timeOfExam, Question[] questions)
        {
            TimeOfExam = timeOfExam;
            Questions = questions ?? Array.Empty<Question>();
            nextIndex = Questions.Length;
        }

        public void AddQuestion(Question question)
        {
            if (Questions == null || nextIndex >= Questions.Length)
                throw new InvalidOperationException("All question slots are already filled.");

            Questions[nextIndex] = question;
            nextIndex++;
        }

        public abstract void ShowExam();
        public abstract object Clone();

        public override string ToString()
        {
            return $"{GetType().Name}: {NumberOfQuestions} question(s), duration {TimeOfExam}";
        }



    }
}
