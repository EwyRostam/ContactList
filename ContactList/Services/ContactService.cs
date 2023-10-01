﻿

using ContactList.Interfaces;
using ContactList.Models;
using Newtonsoft.Json;

namespace ContactList.Services;

public class ContactService : IContactService
{
    public List<Contact> _contacts = new List<Contact>();

        public bool CreateContact(Contact contact)
        {
          try
          {
            if(contact!=null)
            {
                _contacts.Add(contact);

                FileService.SaveToFile(JsonConvert.SerializeObject(_contacts));

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

            FileService.SaveToFile(JsonConvert.SerializeObject(_contacts));
            return true;
        }
        catch { }
        return false;
    }

    public IEnumerable<Contact> GetAll()
    {
        var content = FileService.ReadFromFile();

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
        var contact = _contacts.FirstOrDefault(expression, null!);
        return contact;
    }

   
}
