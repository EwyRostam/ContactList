using ContactList.Interfaces;
using ContactList.Models;
using ContactList.Services;
using Moq;
using System.Collections.Generic;
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

        

    

        //[Fact]

        ////NameOfMethod_Scenario_ExpectedResult
        //public void CreateContact_IfContactIsAddedToList_ReturnTrue()
        //{
        //    //Arrange
        //    contact.Adress = adress;


        //    //Act
        //    bool result = _contactService.CreateContact(contact);

        //    //Assert
        //    Assert.True(result);
        //}

        //[Fact]

        //public void DeleteContact_IfContactIsDeleted_ReturnTrue()
        //{
        //    //Arrange
        //    contact.Adress = adress;

        //    //Act
        //    bool result = _contactService.Delete(contact);

        //    //Assert
        //    Assert.True(result);
        //}

        [Fact]

        public void CreateContactMock_IfContactCreated_ReturnTrue()
        {
            // Arrange
            contact.Adress = adress;
            Mock<IFileService> mockFileService = new Mock<IFileService>();

            IContactService contactService = new ContactService();

            // Act
            bool result = contactService.CreateContact(contact);

            // Assert
            Assert.True(result);
        }

        //[Fact]

        //public void GetSpecificContact_IfContactFound_ReturnContact()
        //{
        //    //Arrange
        //    contact.Adress = adress;
        //    var email = contact.Email;

        //    Mock<IContactService> mockContactService = new Mock<IContactService>();

        //    mockContactService.Setup(contact => contact.GetSpecific(contact => contact.Email == email)).Returns(contact);



        //    IContactService contactService = new ContactService();

        //    // Act
        //    Contact result = contactService.GetSpecific(contact => contact.Email == email);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsAssignableFrom<IUser>(result);
        //    Assert.NotNull(result.Id);
        //    Assert.True(Guid.TryParse(result.Id, out Guid id));

        //    //Act

        //    //Assert
        //}
    }
}