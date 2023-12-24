using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Repositories
{
    public interface ICountryRepository
    {
        Task<List<CountryResponse>> GetAll();

        CountryResponse? GetById(int id);

        CountryResponse? Create(CountryRequest request);

        CountryResponse? Delete(int id);

        CountryResponse? Update(CountryRequest request);
    }
}
