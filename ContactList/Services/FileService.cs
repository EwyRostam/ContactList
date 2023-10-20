

using ContactList.Interfaces;

namespace ContactList.Services;

public class FileService : IFileService
{
    
    private static readonly string filePath = @"C:\Users\ewyro\Nackademin\Contactlist\Contacts.json";



    public void SaveToFile(string contentAsJson)
    {
        //Using means that local variables are deleted when scope ends and opened files are closed.
        //StreamWriter "streams" the content of a string to a file witch is created if it does not already exist. 
        using StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(contentAsJson);
    }

    public string ReadFromFile()
    {
        
        if (File.Exists(filePath))
        {
            //StreaReader streams the content from a file into a string.
            using StreamReader sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        return null!;
    }
}
