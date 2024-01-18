using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonyWebApi.Models
{
    public class CandidateProfilePicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PictureId { get; set; }

        public string? PictureType { get; set; }

        [Required]
        public Guid CandidateIdRef { get; set; }
        public Candidate Candidate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
