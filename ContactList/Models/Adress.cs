

namespace ContactList.Models;

public class Adress
{
    public string? Street { get; set; } = null!;
    public string? StreetNumber { get; set; } = null !; 
    public string? City { get; set; } = null!;

    public string? PostalCode { get; set; } = null!;

    public string? FullAdress => $"{Street} {StreetNumber}, {PostalCode} {City}";
}
