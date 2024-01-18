using MatrimonyWebApi.Data;
using System.ComponentModel.DataAnnotations;

namespace MatrimonyWebApi.ViewModels
{
    public class CandidatePictureRequest
    {
        public int? PictureId { get; set; }
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile FileDetails { get; set; }

        [Required]
        public Guid CandidateId { get; set; }
    }

    public class CandidatePictureResponse : CandidatePictureRequest
    {
        public string PictureUrl { get; set; }
    }
}
