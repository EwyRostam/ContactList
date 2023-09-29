

namespace ContactList.Models;

internal class Adress
{
    public string? Street { get; set; }
    public string? StreetNumber { get; set; }
    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? FullAdress => $"{Street} {StreetNumber}, {PostalCode} {City}";
}
