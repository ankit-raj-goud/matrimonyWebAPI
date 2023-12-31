using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Repositories
{
    public interface IStateRepository
    {
        List<StateMasterResponse> GetAll();

        StateMasterResponse? GetById(int id);

        StateMasterResponse? Create(StateMasterRequest request);

        StateMasterResponse? Delete(int id);

        StateMasterResponse? Update(StateMasterRequest request);

    }
}
