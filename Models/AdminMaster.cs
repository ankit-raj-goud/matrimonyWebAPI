using System.ComponentModel.DataAnnotations;

namespace MatrimonyWebApi.Models
{
    public class AdminMaster
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
