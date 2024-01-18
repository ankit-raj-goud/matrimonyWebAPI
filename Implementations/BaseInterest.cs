using MatrimonyWebApi.Data;
using MatrimonyWebApi.Models;
using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MatrimonyWebApi.Implementations
{
    public class BaseInterest : IInterestRepository
    {
        private readonly MatrimonyDbContext dbContext;

        public BaseInterest(MatrimonyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<InterestResponse> GetInterests(Guid? senderId = null, Guid? receiverId = null, int? statusId = null)
        {
            try
            {
                var query = dbContext.Interests
                    .Include(inc => inc.SenderCandidate)
                    .Include(inc => inc.ReceiverCandidate)
                    .Include(inc => inc.InterestStatusMaster)
                    .AsQueryable();

                if(senderId != null)
                {
                    query = query.Where(whr => whr.SenderIdRef == senderId);
                }

                if(receiverId != null) 
                {
                    query = query.Where(whr => whr.ReceiverIdRef == receiverId);
                }

                if(statusId != null)
                {
                    query = query.Where(whr => whr.InterestStatusId == statusId);
                }

                var recordList = query.OrderByDescending(ord => ord.CreatedDate).ToList();

                var responseList = new List<InterestResponse>();

                foreach (var record in recordList)
                {
                    var response = GetInterestResponse(record);
                    responseList.Add(response);
                }

                return responseList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public InterestResponse? SendInterest(InterestRequest request)
        {
            try
            {
                //check existing record 
                var existingRecord = GetExistingInterest(request);

                if(existingRecord == null)
                {
                    //check if sender has received interest from receiver

                    var reverseExistingRequest = request;
                    reverseExistingRequest.SenderIdRef = null;
                    reverseExistingRequest.ReceiverIdRef = request.SenderIdRef;

                    var reverseExistingRecord = GetExistingInterest(reverseExistingRequest);

                    if(reverseExistingRecord == null)
                    {
                        var newRecord = new Interest
                        {
                            SenderIdRef = request.SenderIdRef.Value,
                            ReceiverIdRef = request.ReceiverIdRef.Value,
                            InterestStatusId = InterestStatusType.open.Value
                        };

                        dbContext.Interests.Add(newRecord);
                        dbContext.SaveChanges();

                        newRecord = GetById(newRecord.InterestId);

                        var response = GetInterestResponse(newRecord);

                        return response;
                    }
                    else
                    {
                        throw new BadHttpRequestException("Record already exists !!");
                    }
                }
                else
                {
                    throw new BadHttpRequestException("Record already exists !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public InterestResponse? UpdateInterest(InterestRequest request)
        {
            try
            {
                var existingRecord = GetById(request.InterestId.Value);

                if(existingRecord != null)
                {
                    existingRecord.InterestStatusId = request.InterestStatusId.Value;

                    dbContext.Interests.Update(existingRecord);
                    dbContext.SaveChanges();

                    var response = GetInterestResponse(existingRecord);
                    return response;
                }
                else
                {
                    throw new BadHttpRequestException("Record already exists !!");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private Interest? GetExistingInterest(InterestRequest request)
        {
            var query = dbContext.Interests
                .Include(inc => inc.SenderCandidate)
                    .Include(inc => inc.ReceiverCandidate)
                    .Include(inc => inc.InterestStatusMaster)
                    .AsQueryable();

            if(request.InterestId != null)
            {
                query = query.Where(whr => whr.InterestId == request.InterestId);
            }

            if (request.SenderIdRef != null)
            {
                query = query.Where(whr => whr.SenderIdRef == request.SenderIdRef);
            }

            if (request.ReceiverIdRef != null)
            {
                query = query.Where(whr => whr.ReceiverIdRef == request.ReceiverIdRef);
            }

            if (request.InterestStatusId != null)
            {
                query = query.Where(whr => whr.InterestStatusId == request.InterestId);
            }

            var record = query.FirstOrDefault();

            return record;
        }

        private InterestResponse? GetInterestResponse(Interest? request)
        {
            try
            {                
                var response = new InterestResponse
                {
                    InterestId = request.InterestId,
                    SenderIdRef = request.SenderIdRef,
                    SenderName = request.SenderCandidate?.Name ?? string.Empty,
                    ReceiverIdRef = request.ReceiverIdRef,
                    ReceiverName = request.ReceiverCandidate?.Name ?? string.Empty,
                    InterestStatusId = request.InterestStatusId,
                    InterestStatus = request.InterestStatusMaster?.InterestStatus ?? string.Empty,
                    Time = request.CreatedDate
                };

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Interest? GetById(int id) 
        {
            try
            {
                var record = dbContext.Interests
                    .Include(inc => inc.SenderCandidate)
                    .Include(inc => inc.ReceiverCandidate)
                    .Include(inc => inc.InterestStatusMaster)
                    .FirstOrDefault(whr => whr.InterestId == id);

                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        InterestResponse? IInterestRepository.GetById(int id)
        {
            try
            {
                var record = GetById(id);

                if(record != null)
                {
                    var response = GetInterestResponse(record);

                    return response;
                }
                else
                {
                    throw new BadHttpRequestException("no data found !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
