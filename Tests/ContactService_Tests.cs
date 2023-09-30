using ContactList.Models;
using ContactList.Services;
using Xunit;

namespace Tests
{
    public class ContactService_Tests
    {
        [Fact]

        //NameOfMethod_Scenario_ExpectedResult
        public void CreateContact_IfContactIsNotAddedToList_ReturnFalse()
        {
            //Arrange
            ContactService _contactService = new ContactService();
            var contact = new Contact();


            //Act
            bool result = _contactService.CreateContact(contact);

            //Assert
            Assert.False(result);
        }
    }
}