using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonyWebApi.Models
{
    public class Donation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonationId { get; set; }
        public string DonerName { get; set; }
        public double Amount { get; set; }
        
        [StringLength(100)]
        public string Address { get; set; }
        
        [StringLength(250)]
        public string Description { get; set; }

        //city master ref
        public int CityId { get; set; }
        public CityMaster? CityMaster { get; set; }
    }
}
