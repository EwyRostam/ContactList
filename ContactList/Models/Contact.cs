﻿

namespace ContactList.Models;

internal class Contact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public Adress Adress { get; set; } = null!;
}