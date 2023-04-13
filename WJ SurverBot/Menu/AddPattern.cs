using System;
using System.Collections.Generic;
using WJ_SurverBot.Json;
using WJ_SurverBot.Survey.Model;

namespace WJ_SurverBot.Menu
{
    internal class SurveyPattern
    {
        public string Name { get; private set; } = "";
        public Uri FormUrl { get; private set; } = new Uri("https://example.com");
        public List<string> Answers { get; } = new List<string>();
        public List<string> TextAreaAnswers { get; } = new List<string>();

        public void AddPattern(IJsonWriter jsonWriter)
        {
            Console.Clear();
            Console.WriteLine("Enter Pattern Name:");
            Name = Console.ReadLine() ?? "";

            Console.WriteLine("Enter Form URL:");
            Uri.TryCreate(Console.ReadLine(), UriKind.Absolute, out Uri? formUrl);
            if (formUrl != null) FormUrl = formUrl;

            AddAnswers("Enter Answers:", "Add Word:", Answers);
            AddAnswers("Enter Text Area Answers", "Add Word:", TextAreaAnswers);
            jsonWriter.SaveDataToJsonFile($"SurveyPatterns/{Name}.json",new SurveyModel(formUrl,Answers,TextAreaAnswers));

        }

        private static void AddAnswers(string startMessage,string message, List<string> answers)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(message);
                string answer = Console.ReadLine() ?? "";

                answers.Add(answer);

                Console.WriteLine("Do you wanna add more words? Y/N");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Y) break;
            }
        }
    }
}
