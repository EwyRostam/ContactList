

using ContactList.Interfaces;
using ContactList.Models;
using Newtonsoft.Json;

namespace ContactList.Services;

internal class ContactService : IContactService
{
    public List<Contact> _contacts = new List<Contact>();

        public bool CreateContact(Contact contact)
        {
          try
          {
            _contacts.Add(contact);

          FileService.SaveToFile(JsonConvert.SerializeObject(_contacts));

            return true;
        }
        catch { }
        return false;
        }




    public void Delete(Contact contact)
    {
        try
        {

          _contacts.Remove(contact);

            FileService.SaveToFile(JsonConvert.SerializeObject(_contacts));
        }
        catch { }



    }

    public IEnumerable<Contact> GetAll()
    {
        var content = FileService.ReadFromFile();

        if (content != null)
        {
            //Omvandlar listan från json-format til C#
            _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            
            return _contacts;
        }
        else
        {
            Console.WriteLine("Kunde inte hitta filen. Vill du ha yoghurt istället?");
            return null!;
        }



    }

    public Contact GetSpecific(Func<Contact, bool> expression)
    {
        var contact = _contacts.FirstOrDefault(expression, null!);
        return contact;
    }

   
}

//{
//    public List<Contact> _contacts = new List<Contact>();

//    public void CreateContact(Contact contact)
//    {
//        _contacts.Add(new Contact
//        {
//            FirstName = contact.FirstName,
//            LastName = contact.LastName,
//            Email = contact.Email,
//            PhoneNumber = contact.PhoneNumber,
//            Adress = contact.Adress
//        });

//        FileService.SaveToFile(JsonConvert.SerializeObject(_contacts));
//    }

//    public void DeleteContact(Contact contact)
//    {
//        _contacts.Remove(contact);

//        FileService.SaveToFile(JsonConvert.SerializeObject(_contacts));
//    }

//    public IEnumerable<Contact> GetAllContacts()
//    {
//        try
//        {
//            var content = FileService.ReadFromFile();

//            if (content != null)
//            {
//                var deserializedContacts = JsonConvert.DeserializeObject<List<Contact>>(content);
//                if (deserializedContacts != null)
//                {
//                    _contacts = deserializedContacts;
//                    return _contacts;
//                }

//                else
//                {
//                    Console.WriteLine("Kunde inte hitta filen.");

//                }



//            }

//        } catch (Exception ex) { Console.WriteLine("Något gick fel! Vänligen testa igen."); }
//        return null!;

//    }

//    //Hämtar ut kontakt om kontakt finns
//    public Contact GetContact(Func<Contact, bool> expression)
//    {
//        var contact = _contacts.FirstOrDefault(expression, null!);
//        return contact;
//    }



//}