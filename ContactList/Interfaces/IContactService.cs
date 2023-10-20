

using ContactList.Models;
using ContactList.Services;

namespace ContactList.Interfaces;

public interface IContactService
{
    
        public bool CreateContact(Contact contact);
        public bool Delete(Contact contact);
   

        IEnumerable<Contact> GetAll();

        public Contact GetSpecific(Func<Contact, bool> expression);

    public bool UpdateContact(IFileService _fileService);

        

    
}
