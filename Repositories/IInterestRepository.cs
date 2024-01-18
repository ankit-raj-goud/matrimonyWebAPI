using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Repositories
{
    public interface IInterestRepository
    {
        InterestResponse? GetById(int id);
        InterestResponse? SendInterest(InterestRequest request);
        InterestResponse? UpdateInterest(InterestRequest request);

        List<InterestResponse> GetInterests
            (
                Guid? senderId = null,
                Guid? receiverId = null, 
                int? statusId = null
            );
    }
}
