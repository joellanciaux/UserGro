namespace UserGro.Model.Interfaces
{
    public interface ILocation
    {
        bool OnlineOnly { get; set; }
        string WebAddress { get; set; }

        string StreetAddress { get; set; }
        string City { get; set; }
        string State { get; set; }
        string PostalCode { get; set; }
        string Country { get; set; }
    }
}