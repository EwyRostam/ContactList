

namespace ContactList.Interfaces;

public interface IFileService
{
    public void SaveToFile(string contentAsJson);

    public string ReadFromFile();

}
