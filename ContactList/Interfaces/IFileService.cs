

namespace ContactList.Interfaces;

public interface IFileService
{
    public void SaveToFile(string contentAsJson); //Will convert list to json-format and save down to file

    public string ReadFromFile(); //Will read the content of the file and convert from json-format to code

}
