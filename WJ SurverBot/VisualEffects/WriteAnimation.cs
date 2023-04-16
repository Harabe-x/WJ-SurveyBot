namespace WJ_SurveyBot.VisualEffects;

internal class WriteAnimation : IWriteAnimation
{
    public void Write(string text, TimeSpan delay)
    {
        for (var i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            if (text[i] == ' ')
                continue;
            Thread.Sleep(delay.Milliseconds);
        }

        Console.WriteLine();
    }

    public void Pause()
    {
        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey(true);
    }
}