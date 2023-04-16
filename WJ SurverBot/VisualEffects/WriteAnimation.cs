namespace WJ_SurveyBot.VisualEffects;

internal class WriteAnimation : IWriteAnimation
{
    public void Write(string text, TimeSpan delay)
    {
        foreach (var t in text)
        {
            Console.Write(t);
            if (t == ' ')
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