using MatrimonyWebApi.Models;

namespace MatrimonyWebApi.ViewModels
{
    public class CountryRequest : Country
    {
        public new int? CountryId
        {
            get { return base.CountryId; }
            set { base.CountryId = value.Value; }
        }
    }

    public class CountryResponse : CountryRequest
    {
    }
}
