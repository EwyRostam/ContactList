﻿

using ContactList.Interfaces;
using ContactList.Models;

namespace ContactList.Services;

internal interface IMenuService
{
    public void MainMenu();
    public void CreateMenu();
    public void ListAllMenu();
    public void ListSpecificMenu();
    public void DeleteMenu();
}

internal class MenuService : IMenuService

{ 
    private readonly IContactService _contactService = new ContactService();

    public void MainMenu()
    {
        var exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Skapa en ny kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa en specifik kontakt");
            Console.WriteLine("4. Radera en kontakt");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("Välj ett av ovanstående alternativ (0-4): ");
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
        Console.Clear();
        Console.WriteLine("Lägg till en ny kontakt");
        Console.WriteLine("-----------------------");

        var contact = new Contact();

        Console.Write("Förnamn: ");
        string firstName = Console.ReadLine()!.Trim().ToLower();
        contact.FirstName = char.ToUpper(firstName[0]) + firstName.Substring(1);

        Console.Write("Efternamn: ");
        string lastName = Console.ReadLine()!.Trim().ToLower();
        contact.LastName = char.ToUpper(lastName[0]) + lastName.Substring(1);

        Console.Write("E-post: ");
        contact.Email = Console.ReadLine()!.Trim().ToLower();

        Console.Write("Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine()!.Trim();


        contact.Adress = new Adress();

        Console.Clear() ;
        Console.WriteLine("Adress");
        Console.WriteLine("-------------");
        Console.Write("Gata: ");
        contact.Adress.Street = Console.ReadLine();
        Console.Write("Gatunummer: ");
        contact.Adress.StreetNumber = Console.ReadLine();
        Console.Write("Stad: ");
        contact.Adress.City = Console.ReadLine();
        Console.Write("Postkod: ");
        contact.Adress.PostalCode = Console.ReadLine();

        _contactService.CreateContact(contact);

        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Din kontakt har blivit tillagd i kontaktlistan!");
        Console.ReadKey();


    }

    public void ListAllMenu()
    {
        Console.Clear();
        Console.WriteLine("Visa alla Kontakter");
        Console.WriteLine("---------------------");

        foreach (var contact in _contactService.GetAll())
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} {contact.Adress.FullAdress}");
            Console.WriteLine();
        }
        Console.ReadKey();
    }

    public void ListSpecificMenu()
    {
        Console.Clear();
        Console.WriteLine("Sök efter kontakten");
        Console.WriteLine("---------------------");
        Console.Write("Ange e-postadress: ");

        var email = Console.ReadLine()!.Trim().ToLower();
        var contact = _contactService.GetSpecific(contact => contact.Email == email);

        if (contact != null)
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} {contact.Adress.FullAdress}");

        else
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Kunde inte hitta någon kontakt med epostadressen \"{email}\"");
            Console.ReadKey();
        }
    }

    public void DeleteMenu()
    {
        Console.Clear();
        Console.WriteLine("Sök efter den kontakt du vill radera");
        Console.WriteLine("------------------------------------");
        Console.Write("Ange e-postadress: ");

        var email = Console.ReadLine()!.Trim().ToLower();
        var contact = _contactService.GetSpecific(contact => contact.Email == email);

        if (contact != null)
        {
            Console.WriteLine();
            Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.PhoneNumber} {contact.Adress.FullAdress}");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Tryck på valfri tangent för att radera kontakten");
            Console.ReadKey();
            _contactService.Delete(contact);
            Console.Clear();
            Console.Clear();

            for (var i = 0; i < 20; i++)
            {
                Console.Write("*");
                Thread.Sleep(125);
            }
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine($"Kontakten \"{contact.FirstName} {contact.LastName}\"  är nu raderad från kontaktlistan.");
            Thread.Sleep(2000);
            Console.Clear();
        }


        else
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Kunde inte hitta någon kontakt med epostadressen \"{email}\"");
            Console.ReadKey();
        }

    }

}
