using System.ComponentModel.DataAnnotations;

namespace MatrimonyWebApi.ViewModels
{
    public class ReligionMasterRequest
    {
        public Guid? ReligionId { get; set; }
        [Required]
        public string? ReligionName { get; set; }
    }

    public class ReligionMasterResponse : ReligionMasterRequest
    {

    }
}
