using System.Text.RegularExpressions;
using System.Xml;

namespace ConsoleApp1;

public class FileNameGetter
{
    private readonly Dictionary<string, string> keyToFileNameDict;

    public FileNameGetter(Dictionary<string, string> keyToFileNameDict)
    {
        this.keyToFileNameDict = keyToFileNameDict;
    }
    
    public string GetFileName(string key)
    {
        return keyToFileNameDict[key];
    }
}