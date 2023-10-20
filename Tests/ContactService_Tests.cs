using ContactList.Interfaces;
using ContactList.Models;
using ContactList.Services;
using Moq;
using Xunit;

namespace Tests
{

    public class ContactService_Tests 
    {

        private readonly Mock<IFileService> mockFileService = new Mock<IFileService>();
        private static readonly IFileService fileService = new FileService();



        Adress adress = new Adress()
        {
            Street = "Brännkyrkagatan",
            StreetNumber = "66",
            City = "Stockholm",
            PostalCode = "118 23",

        };

       
        Contact contact = new Contact()
        {
            FirstName = "Ewy",
            LastName = "Rostam",
            Email = "ewyrostam@gmail.com",
            PhoneNumber = "072 851 80 95",
        };



        [Fact]

        //NameOfMethod_Scenario_ExpectedResult
        public void CreateContact_IfContactIsAddedToList_ReturnTrue() //Integration test
        {
            //Arrange
            ContactService _contactService = new ContactService(fileService);
            contact.Adress = adress;


            //Act
            bool result = _contactService.CreateContact(contact);

            //Assert
            Assert.True(result);

            //Cleanup
            _contactService.Delete(contact);
        }

       

        [Fact]

        public void UpdateContact_IfContactIsUpdated_ReturnTrue() //Unit Test
        {
            //Arrange
            ContactService _contactService = new ContactService(mockFileService.Object);
            contact.Adress = adress;
            contact.FirstName = "Anna";
           

            //Act
            bool result = _contactService.UpdateContact(mockFileService.Object);

            //Assert
            Assert.True(result);
        }

        

    }
}