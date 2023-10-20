

using ContactList.Interfaces;
using ContactList.Models;

namespace ContactList.Services;

internal interface IMenuService
{
    public void MainMenu();
    public void CreateMenu();
    public void ListAllMenu();
    public Contact ListSpecificMenu();
    public void UpdateMenu();
    public void DeleteMenu();
}

internal class MenuService : IMenuService

{ 
    
    private static readonly IFileService _fileService = new FileService();
    private readonly IContactService _contactService = new ContactService(_fileService);

    public void MainMenu()
    {
        var exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Create new contact");
            Console.WriteLine("2. Show all contacts");
            Console.WriteLine("3. Show details for specific contact");
            Console.WriteLine("4. Update a contact");
            Console.WriteLine("5. Delete a contact");
            Console.WriteLine("0. Close program");
            Console.Write("Choose one of the above alternatives (0-5): ");
            var option = Console.ReadLine();
            

            switch (option)
            {
                case "1":
                    CreateMenu();
                    break;

                case "2":
                    ListAllMenu();
                    break;

                case "3":
                    ListSpecificMenu();
                    break;
                
                case "4":
                    UpdateMenu();
                    break;

                case "5":
                    DeleteMenu();
                    break;

                case "0":
                    exit = true;
                    break;

                default:
                    break;
            }

        } while (exit == false);
    }

    public void CreateMenu()
    {
        Console.Clear(); //Clears field from main menu
        Console.WriteLine("Add a new contact");
        Console.WriteLine("-----------------------");

        var contact = new Contact(); //Instance of new contact

        Console.Write("First name: ");
        string firstName = Console.ReadLine()!.Trim().ToLower(); 
        if (firstName.Length > 0)
            contact.FirstName = char.ToUpper(firstName[0]) + firstName.Substring(1); //Makes first letter big if the name is longes than one letter

        Console.Write("Surname: ");
        string lastName = Console.ReadLine()!.Trim().ToLower();
        if (lastName.Length > 0)
            contact.LastName = char.ToUpper(lastName[0]) + lastName.Substring(1);

        Console.Write("Email: ");
        contact.Email = Console.ReadLine()!.Trim().ToLower();

        Console.Write("Phone number: ");
        contact.PhoneNumber = Console.ReadLine()!.Trim();


        contact.Adress = new Adress();

        Console.Clear() ;
        Console.WriteLine("Adress");
        Console.WriteLine("-------------");
        Console.Write("Street: ");
        contact.Adress.Street = Console.ReadLine();
        Console.Write("Street number: ");
        contact.Adress.StreetNumber = Console.ReadLine();
        Console.Write("City: ");
        contact.Adress.City = Console.ReadLine();
        Console.Write("Postal code: ");
        contact.Adress.PostalCode = Console.ReadLine();

        _contactService.CreateContact(contact);

        Console.Clear();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Your contact has been added to the contactlist!");
        Console.ReadKey();


    }

    public void ListAllMenu()
    {
        
        Console.Clear();
        Console.WriteLine("Show all contacts");
        Console.WriteLine("---------------------");

        if (_contactService.GetAll() != null)
        {
            foreach (var contact in _contactService.GetAll()) //Loop for all contacts in list
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} {contact.Adress.FullAdress}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("The contactlist is empty. There are no contacts to show.");
            Thread.Sleep(2000); //Leaves the message for 2 seconds
            Console.Clear();
            for (var i = 0; i < 20; i++) //Prints 20 stars one after the other
            {
                Console.Write("*");
                Thread.Sleep(125);
            }
            Thread.Sleep(250);
            Console.Clear();
            MainMenu();
        }
        
    }

    public Contact ListSpecificMenu()
    {
        Console.Clear();
        Console.WriteLine("Search for the contact");
        Console.WriteLine("---------------------");
        Console.Write("Email: ");

        var email = Console.ReadLine()!.Trim().ToLower();
        var contact = _contactService.GetSpecific(contact => contact.Email == email); //Compares the email with the email with the contacts in the list and returns the first one matching.

        if (contact != null)
        {
            Console.WriteLine();
            Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.PhoneNumber} {contact.Adress.FullAdress}");
            Console.ReadLine();
            return contact;
        }

        else
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Couldn't find any contact with the email: \"{email}\"");
            Console.ReadKey();
            return null!;
        }
    }

    public void UpdateMenu()
    {
        try
        {
            var exit = false;

            Contact contact = ListSpecificMenu(); //Gets a contact from list through "ListSpecificMenu"

            if(contact != null ) 
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Update first name");
                    Console.WriteLine("2. Update last name");
                    Console.WriteLine("3. Update email");
                    Console.WriteLine("4. Update phone number");
                    Console.WriteLine("5. Update adress");
                    Console.WriteLine("0. Go back");
                    Console.Write("Choose one of the above options (0-5): ");
                    var option = Console.ReadLine();
                    Console.Clear();


                    switch (option)
                    {
                        case "1":
                            Console.Write("Enter new first name: ");
                            string firstName = Console.ReadLine()!.Trim().ToLower();
                            if (firstName.Length > 0)
                                contact.FirstName = char.ToUpper(firstName[0]) + firstName.Substring(1);
                            
                            Console.WriteLine("First name has now been updated!");
                            break;

                        case "2":
                            Console.Write("Enter new surname: ");
                            string lastName = Console.ReadLine()!.Trim().ToLower();
                            if (lastName.Length > 0)
                                contact.FirstName = char.ToUpper(lastName[0]) + lastName.Substring(1);
                            Console.Clear();
                            Console.WriteLine("Surname has now been updated!");
                            break;

                        case "3":
                            Console.Write("Enter new email: ");
                            contact.Email = Console.ReadLine()!.Trim().ToLower();
                            Console.Clear();
                            Console.WriteLine("The email has now been updated!");
                            break;

                        case "4":
                            Console.Write("Enter new phone number: ");
                            contact.PhoneNumber = Console.ReadLine()!.Trim();
                            Console.Clear();
                            Console.WriteLine("The phone number has now been updated!");
                            break;

                        case "5":
                            Console.Clear();
                            Console.WriteLine("New adress");
                            Console.WriteLine("-------------");
                            Console.Write("Street: ");
                            contact.Adress.Street = Console.ReadLine();
                            Console.Write("Street number: ");
                            contact.Adress.StreetNumber = Console.ReadLine();
                            Console.Write("City: ");
                            contact.Adress.City = Console.ReadLine();
                            Console.Write("Postal code: ");
                            contact.Adress.PostalCode = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("The adress has now been updated!");
                            break;

                        case "0":
                            exit = true;
                            break;

                        default:
                            break;
                    }

                } while (exit == false);

                _contactService.UpdateContact(_fileService);

            }

        }
           


           
        catch { }
    }

    public void DeleteMenu()
    {
        Console.Clear();
        Console.WriteLine("Search for the contact you want to delete");
        Console.WriteLine("------------------------------------");
        Console.Write("Email: ");

        var email = Console.ReadLine()!.Trim().ToLower();
        var contact = _contactService.GetSpecific(contact => contact.Email == email);

        if (contact != null)
        {
            Console.WriteLine();
            Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.PhoneNumber} {contact.Adress.FullAdress}");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Press any key to delete contact");
            Console.ReadKey();
            _contactService.Delete(contact);
            Console.Clear();
            

            for (var i = 0; i < 20; i++)
            {
                Console.Write("*");
                Thread.Sleep(125);
            }
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine($"Your contact \"{contact.FirstName} {contact.LastName}\"  has now been deleted from the contactlist.");
            Thread.Sleep(2000);
            Console.Clear();
        }


        else
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Couldn't find any contact with the email: \"{email}\"");
            Console.ReadKey();
        }

    }


}
