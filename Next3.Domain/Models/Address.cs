using Next3.Domain.Core.Models;

namespace Next3.Domain.Models
{
    public class Address : Entity
    {
        public Address(string street, int number, string complement,
                        string city, string district, string country,
                        decimal longitude, decimal latitude, string zipCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            District = district;
            Country = country;
            Longitude = longitude;
            Latitude = latitude;
            ZipCode = zipCode;
        }


        public Address() { }

        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string ZipCode { get; set; }
    }
}
