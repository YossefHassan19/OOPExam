using OOPExam.Classes;
using OOPExam.Enum;

namespace OOPExam
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("===== Examination System =====\n");


            int subjectId = ReadInt("Enter Subject Id: ");
            string subjectName = ReadNonEmptyString("Enter Subject Name: ");
            var subject = new Subject(subjectId, subjectName);


            ExamType examType = ReadExamType();
            int minutes = ReadInt("Enter exam duration in minutes: ");


            int numberOfQuestions = ReadInt("How many questions do you want to add? ");
            subject.CreateExam(examType, TimeSpan.FromMinutes(minutes), numberOfQuestions);


            for (int i = 1; i <= numberOfQuestions; i++)
            {
                Console.WriteLine($"\n--- Question {i} of {numberOfQuestions} ---");
                Question question = ReadQuestion(examType, i);
                subject.exam.AddQuestion(question);
            }


            Console.WriteLine();
            bool ready = ReadYesNo("Are you ready to start the exam? (y/n): ");
            if (!ready)
            {
                Console.WriteLine("Okay, exiting without starting the exam.");
                return;
            }

            Console.WriteLine();
            subject.exam.ShowExam();


            if (subject.exam is PracticalExam practicalExam)
            {
                Console.WriteLine();
                bool finished = ReadYesNo("Have you finished the exam? (y/n): ");
                if (finished)
                {
                    Console.WriteLine();
                    practicalExam.ShowRightAnswers();
                }
            }

            Console.WriteLine("\nDone.");
        }


        private static Question ReadQuestion(ExamType examType, int index)
        {
            string header = ReadNonEmptyString("  Header (e.g. Q" + index + "): ");
            string body = ReadNonEmptyString("  Question body: ");
            int mark = ReadInt("  Mark: ");


            int questionTypeChoice = 2;
            if (examType == ExamType.Final)
            {
                Console.WriteLine("  Question type: 1) True/False   2) MCQ");
                questionTypeChoice = ReadIntInRange("  Choose (1 or 2): ", 1, 2);
            }

            if (questionTypeChoice == 1)
            {
                bool correctIsTrue = ReadYesNo("  Is the correct answer 'True'? (y/n): ");
                return new TFQuestion(header, body, mark, correctIsTrue);
            }


            int answerCount = ReadIntInRange("  How many answer options? ", 2, 10);
            var answers = new Answer[answerCount];
            for (int a = 0; a < answerCount; a++)
            {
                string text = ReadNonEmptyString($"    Answer #{a + 1} text: ");
                answers[a] = new Answer(a + 1, text);
            }

            int correctId = ReadIntInRange(
                $"  Enter the Id (1-{answerCount}) of the correct answer: ", 1, answerCount);

            return new MCQQuestion(header, body, mark, answers, correctId);
        }



        private static ExamType ReadExamType()
        {
            Console.WriteLine("Exam type: 1) Final   2) Practical");
            int choice = ReadIntInRange("Choose (1 or 2): ", 1, 2);
            return choice == 1 ? ExamType.Final : ExamType.Practical;
        }

        private static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();
                Console.WriteLine("  Value can't be empty, try again.");
            }
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                    return value;
                Console.WriteLine("  Please enter a valid whole number.");
            }
        }

        private static int ReadIntInRange(string prompt, int min, int max)
        {
            while (true)
            {
                int value = ReadInt(prompt);
                if (value >= min && value <= max)
                    return value;
                Console.WriteLine($"  Please enter a number between {min} and {max}.");
            }
        }

        private static bool ReadYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim().ToLower();
                if (input == "y" || input == "yes") return true;
                if (input == "n" || input == "no") return false;
                Console.WriteLine("  Please answer y or n.");
            }
        }



    }
}
