using System.ComponentModel.DataAnnotations;

namespace MatrimonyWebApi.ViewModels
{
    public class DonationRequest
    {
        public int DonationId { get; set; }
        [Required]
        public string? DonerName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        //city master ref
        public int CityId { get; set; }
    }

    public class DonationResponse : DonationRequest
    {
        public string? CityName { get; set; }
    }
}
