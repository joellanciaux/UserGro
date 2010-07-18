using System;
using UserGro.Model.Interfaces;

namespace UserGro.Model
{
    public class Event: ILocation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }

        public bool OnlineOnly { get; set; }
        public string WebAddress { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}