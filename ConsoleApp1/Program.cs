using ConsoleApp1;


Console.WriteLine("enter project path");

var root = Console.ReadLine();

Console.WriteLine("enter languages path");

var languagesRoot = Console.ReadLine();

var paths = Directory.GetFiles(root, "*.cs", SearchOption.AllDirectories);

var fileNameGetter = new FileNameGetterCreator(languagesRoot).CreateFileNameGetter();
var corrector = new CorrectorCreator().CreateCorrector(fileNameGetter);

foreach (var path in paths)
{
    corrector.Correct(path);
}
Console.WriteLine(Corrector.ct);