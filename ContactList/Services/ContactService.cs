


using ContactList.Interfaces;
using ContactList.Models;
using Newtonsoft.Json;

namespace ContactList.Services;

public class ContactService : IContactService
{
    public List<Contact> _contacts = new List<Contact>();
    FileService _fileService = new FileService();

        public bool CreateContact(Contact contact)
        {
          try
          {
            var content = _fileService.ReadFromFile();

                //Omvandlar listan från json-format til C#
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
                
            if (contact!=null)
            {
                _contacts.Add(contact);

                _fileService.SaveToFile(JsonConvert.SerializeObject(_contacts));

                return true;
            }
           
        }
        catch { }
        return false;
        }




    public bool Delete(Contact contact)
    {
        try
        {

          _contacts.Remove(contact);

            _fileService.SaveToFile(JsonConvert.SerializeObject(_contacts));
            return true;
        }
        catch { }
        return false;
    }

    public IEnumerable<Contact> GetAll()
    {
        var content = _fileService.ReadFromFile();

        if (content != string.Empty)
        {
            //Omvandlar listan från json-format til C#
            _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            if (_contacts.Count > 0)
                return _contacts;
            else return null!;
        }
        
        else
        {
            
            Console.WriteLine("Kunde inte hitta filen. Vill du ha yoghurt istället?");
            Console.ReadLine();
            return null!;
            
        }



    }

    public Contact GetSpecific(Func<Contact, bool> expression)
    {
        var content = _fileService.ReadFromFile();
        _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;

        var contact = _contacts.FirstOrDefault(expression, null!);
        return contact;
    }

    public void UpdateContact()
    {
        _fileService.SaveToFile(JsonConvert.SerializeObject(_contacts));

    }
}
