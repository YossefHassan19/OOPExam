using OOPExam.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Classes
{
    internal class Subject
    {

        public int subjectId { get; set; }
        public string subjectName { get; set; }
        public Exam exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            this.subjectId = subjectId;
            this.subjectName = subjectName;
        }

        public void CreateExam(ExamType type, TimeSpan timeOfExam, int numberOfQuestions)
        {
            switch (type)
            {
                case ExamType.Final:
                    exam = new FinalExam(timeOfExam, numberOfQuestions);
                    break;
                case ExamType.Practical:
                    exam = new PracticalExam(timeOfExam, numberOfQuestions);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown exam type.");
            }
        }

        public void CreateExam(ExamType type, TimeSpan timeOfExam, Question[] questions)
        {
            switch (type)
            {
                case ExamType.Final:
                    exam = new FinalExam(timeOfExam, questions);
                    break;
                case ExamType.Practical:
                    exam = new PracticalExam(timeOfExam, questions);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown exam type.");
            }
        }


        public override string ToString()
        {
            return $"Subject #{subjectId} - {subjectName}";
        }

    }
}
