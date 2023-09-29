

namespace ContactList.Services;

internal class FileService
{
    private static readonly string filePath = @"C:\Users\ewyro\Nackademin\Contactlist\Contacts.json";
    public static void SaveToFile(string contentAsJson)
    {
        //Using innebär att lokala variabler raderas när scopet är slut. Och att öppnade filer stängs.
        //StreamWriter "streamar" in innehållet från en sträng till en fil som den skapar om inte filen redan finns
        using StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(contentAsJson);
    }

    public static string ReadFromFile()
    {
        if (File.Exists(filePath))
        {
            using StreamReader sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        return null!;
    }
}
