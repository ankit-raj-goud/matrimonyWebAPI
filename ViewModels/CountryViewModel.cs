using MatrimonyWebApi.Models;

namespace MatrimonyWebApi.ViewModels
{
    public class CountryRequest
    { 
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
    }

    public class CountryResponse : CountryRequest
    {
    }
}
