using System.Text.RegularExpressions;

namespace ConsoleApp1;

public class Corrector
{

    public static int ct = 0;
    private readonly Regex _regex;
    private readonly MatchEvaluator _matchEvaluator;

    public Corrector(MatchEvaluator matchEvaluator, Regex regex)
    {
        _matchEvaluator = matchEvaluator;
        _regex = regex;
    }

    public void Correct(string filepath)
    {
        string input = File.ReadAllText(filepath);
        if (_regex.IsMatch(input))
        {
            var usingString = "using MSSE.LAPortal.Language.LanguageDictionary;\n";
            var corrected = _regex.Replace(input, _matchEvaluator);
            ct++;
            corrected = usingString + corrected;
            File.WriteAllText(filepath, corrected);
        }
    }
}