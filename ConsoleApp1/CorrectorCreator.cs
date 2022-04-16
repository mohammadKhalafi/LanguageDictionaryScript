using System.Text.RegularExpressions;

namespace ConsoleApp1;

public class CorrectorCreator
{
    private static readonly string pattern = $@"LanguageDictionary.GetUIEntries\(""(.*?)""(?:\s*,)?";

    public  Corrector CreateCorrector(FileNameGetter fileNameGetter)
    {
        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Multiline);

        string WordScrambler(Match match)
        {
            var key = match.Groups[1].Value;
            try
            {
                return $"LanguageDictionaryProvider.Instance.{fileNameGetter.GetFileName(key)}.{key}(";

            }
            catch (Exception e)
            {
                Console.WriteLine(key);
            }


            return match.Groups[0].Value;
        }

        MatchEvaluator evaluator = new MatchEvaluator(WordScrambler);

        return new Corrector(evaluator, regex);
    }
}