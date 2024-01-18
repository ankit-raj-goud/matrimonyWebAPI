using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonyWebApi.Models
{
    public class Candidate
    {
        [Key]
        public Guid CandidateId { get; set; }
        [Required]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string SubCaste { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public string FamilyType { get; set; }
        public double FamilyIncome { get; set; }
        public bool IsProfilePictureOpenVisible { get; set; }
        public string Description { get; set; }
        public string DesiredPartnerDescription { get; set;}
        public string ContactPerson { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        public bool IsContactNumberOpen { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Color { get; set; }
        public string Profession { get; set; }
        public double PersonalMonthlyIncome { get; set; }

        //city ref
        public int CityIdRef { get; set; }
        public CityMaster CityMaster { get; set; }

        //caste ref
        public Guid CasteIdRef { get; set; }
        public CasteMaster CasteMaster { get; set; }

        //gender ref
        public int GenderIdRef { get; set; }
        public GenderMaster GenderMaster { get; set; }

        public ICollection<CandidateLoginDetails> CandidateLoginDetails { get; set; }

        public ICollection<Interest> SenderInterests { get; set; }
        public ICollection<Interest> ReceiverInterests { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<CandidateProfilePicture> CandidateProfilePictures{ get; set; }

    }

    public class CandidateLoginDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //candidate Id Ref
        public Guid CandidateIdRef { get; set; }
        
        public Candidate Candidate { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
