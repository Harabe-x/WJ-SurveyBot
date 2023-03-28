namespace WJ_SurverBot.Survey.Extension
{
    internal static class CsvReaderExtension
    {
        public static IEnumerable<string> ToCity(this IEnumerable<string> soruce)
        {
            foreach (var line in soruce)
            {
                var splittedLine = line.Split(',');

                yield return splittedLine[0];
            }
        }
    }
}
