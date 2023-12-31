using MatrimonyWebApi.Models;

namespace MatrimonyWebApi.ViewModels
{
    public class CityMasterRequest
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }

        //state master ref
        public int StateId { get; set; }        
    }

    public class CityMasterResponse : CityMasterRequest 
    {
        public string? StateName { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set;}
    }
}
