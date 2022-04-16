using System.Text.RegularExpressions;
using System.Xml;

namespace ConsoleApp1;

public class FileNameGetterCreator
{
    private readonly string languagesRoot;

    public FileNameGetterCreator(string languagesRoot)
    {
        this.languagesRoot = languagesRoot;
    }
    
    public FileNameGetter CreateFileNameGetter()
    {
        return new FileNameGetter(InitializeDict());
    }
    
    private Dictionary<string, string> InitializeDict()
    {
        var keyToFileNameDict = new Dictionary<string, string>();
    
        var fileNames = Directory.GetFiles(languagesRoot, "*.xml");

        foreach (var path1 in fileNames)
        {
            var file = new FileInfo(path1);
            var reader = new XmlTextReader(path1);
            var fileName = file.Name;
            int y = fileName.IndexOf(".xml");
            fileName = fileName.Remove(y, 4);
            fileName = fileName.Replace(".", "_");

            string xmlString = File.ReadAllText(path1);
            var regex = new Regex("<Entry key=\"(.*?)\">");
            var matchedAuthors = regex.Matches(xmlString);

            for (int count = 0; count < matchedAuthors.Count; count++)
            {
                keyToFileNameDict.Add(matchedAuthors[count].Groups[1].Value, fileName);
            }
        }

        return keyToFileNameDict;
    }
}