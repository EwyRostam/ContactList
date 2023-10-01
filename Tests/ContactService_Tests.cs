using ContactList.Models;
using ContactList.Services;
using Xunit;

namespace Tests
{
    public class ContactService_Tests
    {
        Adress adress = new Adress()
        {
            Street = "Brännkyrkagatan",
            StreetNumber = "66",
            City = "Stockholm",
            PostalCode = "118 23",

        };

        ContactService _contactService = new ContactService();
        Contact contact = new Contact()
        {
            FirstName = "Ewy",
            LastName = "Rostam",
            Email =  "ewyrostam@gmail.com",
            PhoneNumber = "072 851 80 95",    
        };

        

       
        


        [Fact]

        //NameOfMethod_Scenario_ExpectedResult
        public void CreateContact_IfContactIsAddedToList_ReturnTrue()
        {
            //Arrange
            contact.Adress = adress;



            //Act
            bool result = _contactService.CreateContact(contact);

            //Assert
            Assert.True(result);
        }

        [Fact]

        public void DeleteContact_IfContactIsDeleted_ReturnTrue()
        {
            //Arrange
            contact.Adress = adress;

            //Act
            bool result = _contactService.Delete(contact);

            //Assert
            Assert.True(result);
        }


    }
}