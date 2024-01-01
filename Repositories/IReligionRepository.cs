using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Repositories
{
    public interface IReligionRepository
    {
        List<ReligionMasterResponse> GetAll();

        ReligionMasterResponse? GetById(Guid id);

        ReligionMasterResponse? Create(ReligionMasterRequest request);

        ReligionMasterResponse? Delete(Guid id);

        ReligionMasterResponse? Update(ReligionMasterRequest request);
    }
}
