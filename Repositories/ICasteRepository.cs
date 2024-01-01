using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Repositories
{
    public interface ICasteRepository
    {
        List<CasteMasterResponse> GetAll();

        CasteMasterResponse? GetById(Guid id);

        CasteMasterResponse? Create(CasteMasterRequest request);

        CasteMasterResponse? Delete(Guid id);

        CasteMasterResponse? Update(CasteMasterRequest request);
    }
}
