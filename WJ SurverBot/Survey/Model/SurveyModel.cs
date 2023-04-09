namespace WJ_SurverBot.Survey.Model
{
    internal class SurveyModel
    {
        public Uri? FormUrl { get; private set; }

        public List<string>? FormAnswers { get; private set; }

        public List<string>? FormTextAreaAnswers { get; private set; }

        public SurveyModel(Uri formUrl , List<string> formAnswers , List<string> formTextAreaAnswers)
        {
            FormAnswers = formAnswers;
            FormTextAreaAnswers = formTextAreaAnswers;
            FormUrl = formUrl;
        }


    }
}
