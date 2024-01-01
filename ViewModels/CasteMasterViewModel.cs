using System.ComponentModel.DataAnnotations;

namespace MatrimonyWebApi.ViewModels
{
    public class CasteMasterRequest
    {
        public Guid CasteId { get; set; }
        public string? CasteName { get; set; }

        //religion master ref
        [Required]
        public Guid ReligionIdRef { get; set; }
    }

    public class CasteMasterResponse : CasteMasterRequest
    {
        public string? ReligionName { get; set; }
    } 
}
