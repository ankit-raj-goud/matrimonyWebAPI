using MatrimonyWebApi.Models;

namespace MatrimonyWebApi.ViewModels
{
    public class InterestRequest
    {
        public int? InterestId { get; set; }
        public Guid? SenderIdRef { get; set; }     

        //receiver ref
        public Guid? ReceiverIdRef { get; set; }        

        //interest status
        public int? InterestStatusId { get; set; }        
    }

    public class InterestResponse : InterestRequest
    {
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string InterestStatus { get; set; }
        public DateTime Time { get; set; }
    }
}
