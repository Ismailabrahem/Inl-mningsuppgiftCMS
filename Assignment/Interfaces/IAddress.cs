namespace Assignment.Interfaces
{
    public interface IAddress                   // Skapar ett interface där dessa adressbeskrivningar måste implementeras. 
    {
        string? City { get; set; }
        string? StreetName { get; set; }
        string? StreetNumber { get; set; }
        string? ZipCode { get; set; }
        string? FullAddress { get; }
    }
}