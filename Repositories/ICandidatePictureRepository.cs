using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Repositories
{
    public interface ICandidatePictureRepository
    {
        Task<CandidatePictureResponse> SaveProfilePicture (CandidatePictureRequest pictureRequest);
        Task<CandidatePictureResponse> UpdateProfilePicture(CandidatePictureRequest pictureRequest);
        Task <CandidatePictureResponse>  DeleteProfilePicture (int pictureId);
        Task<List<CandidatePictureResponse>> GetProfilePicture(Guid candidateId);
    }
}
