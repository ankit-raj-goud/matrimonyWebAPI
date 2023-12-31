using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Repositories
{
    public interface ICityRepository
    {
        List<CityMasterResponse> GetAll();

        CityMasterResponse? GetById(int id);

        CityMasterResponse? Create(CityMasterRequest request);

        CityMasterResponse? Delete(int id);

        CityMasterResponse? Update(CityMasterRequest request);
    }
}
