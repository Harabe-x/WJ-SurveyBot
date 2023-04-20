using WJ_SurveyBot.VisualEffects;

namespace WJ_SurverBot.VisualEffects;

/// <summary>
/// Provides methods for animating the display of text in the console.
/// </summary>
internal class WriteAnimation : IWriteAnimation
{
    /// <summary>
    /// Writes each character in a given string with a delay between each character.
    /// </summary>
    /// <param name="text">The text to write.</param>
    /// <param name="delay">The delay between each character, in milliseconds.</param>
    public void Write(string text, TimeSpan delay)
    {
        foreach (var letter in text)
        {
            Console.Write(letter);
            if (letter == ' ')

                continue;
            Thread.Sleep(delay.Milliseconds);
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Pauses execution and waits for user input before continuing.
    /// </summary>
    public void Pause()
    {
        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey(true);
    }
}