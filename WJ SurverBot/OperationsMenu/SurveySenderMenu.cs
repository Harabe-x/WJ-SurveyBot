using WJ_SurveyBot.Json;
using WJ_SurveyBot.OperationsMenu.OperationsMenu_interfaces;
using WJ_SurveyBot.Survey;

namespace WJ_SurveyBot.OperationsMenu;


/// <summary>
/// Represents a menu for sending surveys.
/// </summary>
internal class SurveySenderMenu : ISurveySenderMenu
{

    /// <summary>
    /// Displays a menu of saved survey patterns and sends answers for the selected pattern.
    /// </summary>
    /// <param name="_surveySender">The survey sender to use for sending answers.</param>
    public async void RunMenu(ISurveySender _surveySender)
    {
        Console.Clear();
        var menuOptions = GetSavedSurveysPatterns(@"SurveyPatterns");


        var surveys = new List<string>();
        var menu = new Menu(menuOptions.Select(file => file.Key).ToArray(), @" 
█     █░▄▄▄██▀▀▀     ██████  █    ██  ██▀███   ██▒   █▓▓█████▓██   ██▓
▓█░ █ ░█░  ▒██      ▒██    ▒  ██  ▓██▒▓██ ▒ ██▒▓██░   █▒▓█   ▀ ▒██  ██▒
▒█░ █ ░█   ░██      ░ ▓██▄   ▓██  ▒██░▓██ ░▄█ ▒ ▓██  █▒░▒███    ▒██ ██░
░█░ █ ░█▓██▄██▓       ▒   ██▒▓▓█  ░██░▒██▀▀█▄    ▒██ █░░▒▓█  ▄  ░ ▐██▓░
░░██▒██▓ ▓███▒      ▒██████▒▒▒▒█████▓ ░██▓ ▒██▒   ▒▀█░  ░▒████▒ ░ ██▒▓░
░ ▓░▒ ▒  ▒▓▒▒░      ▒ ▒▓▒ ▒ ░░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░   ░ ▐░  ░░ ▒░ ░  ██▒▒▒ 
  ▒ ░ ░  ▒ ░▒░      ░ ░▒  ░ ░░░▒░ ░ ░   ░▒ ░ ▒░   ░ ░░   ░ ░  ░▓██ ░▒░ 
  ░   ░  ░ ░ ░      ░  ░  ░   ░░░ ░ ░   ░░   ░      ░░     ░   ▒ ▒ ░░  
    ░    ░   ░            ░     ░        ░           ░     ░  ░░ ░     
Select Survey Pattern");
        var selectedOption = menu.Run();
        Console.Clear();
        Console.WriteLine($"You Selected {menuOptions[selectedOption].Key}");
        var surveyPattern = JsonReader.ReadJsonFile(menuOptions[selectedOption].Value);

        Console.WriteLine("How much form do you wanna send: ");
        int.TryParse(Console.ReadLine(), out var parsedValue);
        for (var i = 0; i < parsedValue; i++) await _surveySender.SendAnswer(surveyPattern.Key, surveyPattern.Value);
    }


    public List<KeyValuePair<string, string>> GetSavedSurveysPatterns(string folderPath)
    {
        var filePaths = Directory.GetFiles(folderPath);

        return filePaths.Select(filePath => new KeyValuePair<string, string>(Path.GetFileName(filePath), filePath)).ToList();
    }
}