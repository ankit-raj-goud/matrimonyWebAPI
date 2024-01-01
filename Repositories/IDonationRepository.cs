using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Repositories
{
    public interface IDonationRepository
    {
        List<DonationResponse> GetAll();

        DonationResponse? GetById(int id);

        DonationResponse? Create(DonationRequest request);

        DonationResponse? Delete(int id);

        DonationResponse? Update(DonationRequest request);
    }
}
