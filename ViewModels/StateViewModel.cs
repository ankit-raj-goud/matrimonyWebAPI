using System.ComponentModel.DataAnnotations;

namespace MatrimonyWebApi.ViewModels
{
    public class StateMasterRequest
    {
        public int StateId { get; set; }

        [Required]
        public string? StateName { get; set; }

        public int CountryId { get; set; }
    }

    public class StateMasterResponse : StateMasterRequest
    {
        public string? CountryName { get; set; }
    }
}
