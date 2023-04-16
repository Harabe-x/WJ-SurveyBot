namespace WJ_SurveyBot.VisualEffects;

internal class AnimatedConsoleTitle
{
    private readonly List<string> _Frames;


    private Thread _thread;


    public AnimatedConsoleTitle()
    {
        _Frames = new List<string>();
    }

    public bool IsRunning { get; private set; }


    public void AddFrames(string[] frames)
    {
        foreach (var frame in frames) _Frames.Add(frame);
    }

    public void StartAnimation()
    {
        if (IsRunning) return;
        IsRunning = true;
        _thread = new Thread(BeginAnimation);
        _thread.Start();
    }

    public void StopAnimation()
    {
        IsRunning = false;
    }

    private void BeginAnimation()
    {
        while (IsRunning)
        {
            for (var i = 0; i < _Frames.Count; i++)
            {
                Console.Title = _Frames[i];
                Thread.Sleep(1000 / _Frames.Count);
            }

            // Waiting half second before starting a new animation
            Thread.Sleep(500);
        }
    }


    public void ClearFrames()
    {
        _Frames.Clear();
    }
}