using WJ_SurveyBot.Json;
using WJ_SurveyBot.OperationsMenu.OperationsMenu_interfaces;
using WJ_SurveyBot.Survey;

namespace WJ_SurveyBot.OperationsMenu;

internal class SurveySenderMenu : ISurveySenderMenu
{
    public async void RunMenu(ISurveySender _surveySender)
    {
        Console.Clear();
        var menuOptions = GetSavedSurveysPatterns(@"SurveyPatterns");


        var surveys = new List<string>();
        var menu = new Menu(menuOptions.Select(file => file.Key).ToArray(), @"Select Survey Pattern");
        var selectedOption = menu.Run();
        Console.Clear();
        Console.WriteLine($"You Selected {menuOptions[selectedOption].Key}");
        var surveyPattern = JsonReader.ReadJsonFile(menuOptions[selectedOption].Value);

        Console.WriteLine("How much form do you wanna send: ");
        int.TryParse(Console.ReadLine(), out var parsedValue);
        for (var i = 0; i < parsedValue; i++)  await _surveySender.SendAnswer(surveyPattern.Key, surveyPattern.Value);
    }


    public List<KeyValuePair<string, string>> GetSavedSurveysPatterns(string folderPath)
    {
        var files = new List<KeyValuePair<string, string>>();

        var filePaths = Directory.GetFiles(folderPath);

        foreach (var filePath in filePaths)
            files.Add(new KeyValuePair<string, string>(Path.GetFileName(filePath), filePath));

        return files;
    }
}