

using ContactList.Interfaces;

namespace ContactList.Services;

public class FileService : IFileService
{
    private static readonly string filePath = @"C:\Users\ewyro\Nackademin\Contactlist\Contacts.json";

  
    public void SaveToFile(string contentAsJson)
    {
        //Using innebär att lokala variabler raderas när scopet är slut. Och att öppnade filer stängs.
        //StreamWriter "streamar" in innehållet från en sträng till en fil som den skapar om inte filen redan finns
        using StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(contentAsJson);
    }

    public string ReadFromFile()
    {
        if (File.Exists(filePath))
        {
            using StreamReader sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        return null!;
    }
}
