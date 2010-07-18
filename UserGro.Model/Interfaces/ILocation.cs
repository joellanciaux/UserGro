namespace UserGro.Model.Interfaces
{
    public interface ILocation
    {
        string StreetAddress { get; set; }
        string City { get; set; }
        string State { get; set; }
        int PostalCode { get; set; }
        string Country { get; set; }
    }
}