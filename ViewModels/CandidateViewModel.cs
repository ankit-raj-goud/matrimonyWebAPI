using MatrimonyWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace MatrimonyWebApi.ViewModels
{
    public class CandidateRequest
    {
        public Guid CandidateId { get; set; }
        [Required]
        public string Name { get; set; }

        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string SubCaste { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public string FamilyType { get; set; }
        public double FamilyIncome { get; set; }
        public bool IsProfilePictureOpenVisible { get; set; }
        public string Description { get; set; }
        public string DesiredPartnerDescription { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public bool IsContactNumberOpen { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Color { get; set; }
        public string Profession { get; set; }
        public double PersonalMonthlyIncome { get; set; }

        //city ref
        public int CityIdRef { get; set; }
        
        //caste ref
        public Guid CasteIdRef { get; set; }        

        //gender ref
        public int GenderIdRef { get; set; }
        
    }

    public class CandidateResponse : CandidateRequest
    {
        public string CityName { get; set; }
        public string CasteName { get; set; }
        public string GenderName { get; set; }
    }
}
