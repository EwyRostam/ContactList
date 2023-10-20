


using ContactList.Interfaces;
using ContactList.Models;
using Newtonsoft.Json;

namespace ContactList.Services;

public class ContactService : IContactService
{
    public List<Contact> _contacts = new List<Contact>();
    private readonly IFileService _fileService;

    public ContactService(IFileService fileService) //Constructor with dependency injection that can be used for the moq-test
    {
        _fileService = fileService;
    }



    public bool CreateContact(Contact contact) 
        {
          try
          {
            //Gets list from file and converts it to C# List. So that new list will not overwrite the old list when saved.
            var content = _fileService.ReadFromFile(); 
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!; 

            //If contact exists, add contact to list and save down to file.
            if (contact!=null)
            {
                _contacts.Add(contact);

                _fileService.SaveToFile(JsonConvert.SerializeObject(_contacts));
            
            //If save to file succeeded
                return true;
            }
           
        }
        catch { }
        //If  save to file failed
        return false;
        }




    public bool Delete(Contact contact)
    {
        try
        {
            //Removes contact and saves updated list to file
          _contacts.Remove(contact);

            _fileService.SaveToFile(JsonConvert.SerializeObject(_contacts));
            //If succeded
            return true;
        }
        catch { }
        //If failed
        return false;
    }

    public IEnumerable<Contact> GetAll()
    {

        var content = _fileService.ReadFromFile();

        if (content != string.Empty)
        {
            
            _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            //When all contacts are deleted from file "[]" remains in json file. Therefore checking the length of the list.
            if (_contacts.Count > 0)
                return _contacts;
            else return null!;
        }
        
        else
        {
            
            Console.WriteLine("Could not find the file you are looking for.");
            Console.ReadLine();
            return null!;
            
        }



    }

    public Contact GetSpecific(Func<Contact, bool> expression)
    {
        //Gets list from file and converts it.
        var content = _fileService.ReadFromFile();
        _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;

        //Finds contact in list, the first one that matches expression in ()
        var contact = _contacts.FirstOrDefault(expression, null!);
        return contact;
    }

    public bool UpdateContact(IFileService _fileService)
    {
        try
        {
            //Save updated list and convert to json-format.
            _fileService.SaveToFile(JsonConvert.SerializeObject(_contacts));
            //If succeeded
            return true;
        } catch { }
        //If failed
        return false;
        

    }
}
