using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Repositories
{
    public interface ICandidateRepository
    {
        List<CandidateResponse> GetAll();

        CandidateResponse? GetById(Guid id);

        CandidateResponse? Create(CandidateRequest request);

        CandidateResponse? Delete(Guid id);

        CandidateResponse? Update(CandidateRequest request);
    }
}
