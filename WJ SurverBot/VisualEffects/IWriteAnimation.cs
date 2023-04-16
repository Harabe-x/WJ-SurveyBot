namespace WJ_SurveyBot.VisualEffects;

internal interface IWriteAnimation
{
    void Write(string text, TimeSpan delay);

    void Pause();
}