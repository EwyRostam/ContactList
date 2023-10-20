

using ContactList.Models;


namespace ContactList.Interfaces;

public interface IContactService
{
    
        public bool CreateContact(Contact contact); //Will add contact to list and call the function to save down list to file.
        public bool Delete(Contact contact); //Will delete contact from list and call function to save down changed list to file.
   

        IEnumerable<Contact> GetAll(); //Will return an IEnumerable of the contactlist

        public Contact GetSpecific(Func<Contact, bool> expression); //Searches for contact in contactlist and returns contact

    public bool UpdateContact(IFileService _fileService); //Saves down updated list to file

        

    
}
