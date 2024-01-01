using Azure.Core;
using MatrimonyWebApi.Data;
using MatrimonyWebApi.Models;
using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;

namespace MatrimonyWebApi.Implementations
{
    public class BaseReligionMaster : IReligionRepository
    {
        private readonly MatrimonyDbContext dbContext;

        public BaseReligionMaster(MatrimonyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ReligionMasterResponse? Create(ReligionMasterRequest request)
        {
            try
            {
                var duplicateData = IsReligionExist(request.ReligionName);

                if (duplicateData != null)
                {
                    throw new BadHttpRequestException("religion already exists !!");
                }

                var newRecord = new ReligionMaster
                {
                    ReligionId = Guid.NewGuid(),    
                    ReligionName = request.ReligionName
                };

                dbContext.ReligionMasters.Add(newRecord);
                dbContext.SaveChanges();

                var responseData = dbContext.ReligionMasters
                    .FirstOrDefault(whr => whr.ReligionId == newRecord.ReligionId);

                var response = new ReligionMasterResponse
                {
                    ReligionId = responseData?.ReligionId,
                    ReligionName = responseData?.ReligionName
                };

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ReligionMasterResponse? Delete(Guid id)
        {
            try
            {
                var existingRecord = dbContext.ReligionMasters
                    .FirstOrDefault(whr => whr.ReligionId == id);

                if (existingRecord != null)
                {
                    dbContext.ReligionMasters.Remove(existingRecord);
                    dbContext.SaveChanges();   

                    var response = new ReligionMasterResponse
                    {
                        ReligionId = existingRecord?.ReligionId,
                        ReligionName = existingRecord?.ReligionName
                    };

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

        public List<ReligionMasterResponse> GetAll()
        {
            try
            {
                var newRecord = dbContext.ReligionMasters.ToList();

                var responseList = new List<ReligionMasterResponse>();

                foreach (var data in newRecord)
                {
                    var record = new ReligionMasterResponse
                    {
                        ReligionId = data.ReligionId,
                        ReligionName = data.ReligionName,
                    };

                    responseList.Add(record);
                }

                return responseList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ReligionMasterResponse? GetById(Guid id)
        {
            try
            {
                var existingRecord = dbContext.ReligionMasters
                    .FirstOrDefault(whr => whr.ReligionId == id);


                if (existingRecord != null)
                {
                    var response = new ReligionMasterResponse
                    {
                        ReligionId = existingRecord?.ReligionId,
                        ReligionName = existingRecord?.ReligionName
                    };

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

        public ReligionMasterResponse? Update(ReligionMasterRequest request)
        {
            try
            {
                var existingRecord = dbContext.ReligionMasters
                    .FirstOrDefault(whr => whr.ReligionId == request.ReligionId);

                if (existingRecord != null)
                {

                    var duplicateData = IsReligionExist(request.ReligionName);

                    if(duplicateData != null && duplicateData.ReligionId != existingRecord.ReligionId)
                    {
                        throw new BadHttpRequestException("religion already exists !!");
                    }

                    existingRecord.ReligionName = request.ReligionName;

                    dbContext.ReligionMasters.Update(existingRecord);
                    dbContext.SaveChanges();

                    var response = new ReligionMasterResponse
                    {
                        ReligionId = existingRecord?.ReligionId,
                        ReligionName = existingRecord?.ReligionName
                    };

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

        private ReligionMaster? IsReligionExist(string name)
        {
            try
            {
                var existingRecord = dbContext.ReligionMasters
                     .FirstOrDefault(whr => whr.ReligionName.ToLower() == name);
                
                return existingRecord;
                               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
