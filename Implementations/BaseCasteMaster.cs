using MatrimonyWebApi.Data;
using MatrimonyWebApi.Models;
using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MatrimonyWebApi.Implementations
{
    public class BaseCasteMaster : ICasteRepository
    {
        private readonly MatrimonyDbContext dbContext;

        public BaseCasteMaster(MatrimonyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public CasteMasterResponse? Create(CasteMasterRequest request)
        {
            try
            {
                var existingRecord = IsCasteExistByName(request.CasteName);

                if(existingRecord == null)
                {
                    var newRecord = new CasteMaster
                    {
                        CasteId = Guid.NewGuid(),
                        CasteName = request.CasteName,
                        ReligionIdRef = request.ReligionIdRef
                    };

                    dbContext.CasteMasters.Add(newRecord);
                    dbContext.SaveChanges();

                    newRecord = dbContext.CasteMasters
                        .Include(inc => inc.ReligionMaster)
                        .First(whr => whr.CasteId == newRecord.CasteId);

                    var response = new CasteMasterResponse
                    {
                        CasteId = newRecord.CasteId,
                        CasteName = newRecord.CasteName,
                        ReligionIdRef = newRecord.ReligionIdRef,
                        ReligionName = newRecord.ReligionMaster?.ReligionName
                    };

                    return response;

                }
                else 
                {
                    throw new BadHttpRequestException("Caste already exists !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CasteMasterResponse? Delete(Guid id)
        {
            try
            {
                var existingRecord = dbContext.CasteMasters
                    .Include(inc => inc.ReligionMaster)
                    .FirstOrDefault(whr => whr.CasteId == id);

                if(existingRecord != null)
                {
                    dbContext.CasteMasters.Remove(existingRecord);
                    dbContext.SaveChanges();

                    var response = new CasteMasterResponse
                    {
                        CasteId = existingRecord.CasteId,
                        CasteName = existingRecord.CasteName,
                        ReligionIdRef = existingRecord.ReligionIdRef,
                        ReligionName = existingRecord.ReligionMaster?.ReligionName
                    };

                    return response;
                }
                else
                {
                    throw new BadHttpRequestException("no data found by id given !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CasteMasterResponse> GetAll()
        {
            try
            {
                var recordList = dbContext.CasteMasters
                    .Include(inc => inc.ReligionMaster)
                    .ToList();

                var responseList = new List<CasteMasterResponse>();

                foreach (var record in recordList)
                {
                    var response = new CasteMasterResponse
                    {
                        CasteId = record.CasteId,
                        CasteName = record.CasteName,
                        ReligionIdRef = record.ReligionIdRef,
                        ReligionName = record.ReligionMaster?.ReligionName
                    };

                    responseList.Add(response); 
                }

                return responseList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CasteMasterResponse? GetById(Guid id)
        {
            try
            {
                var record = dbContext.CasteMasters
                    .Include(inc => inc.ReligionMaster)
                    .FirstOrDefault(whr => whr.CasteId == id);

                if(record != null)
                {
                    var response = new CasteMasterResponse
                    {
                        CasteId = record.CasteId,
                        CasteName = record.CasteName,
                        ReligionIdRef = record.ReligionIdRef,
                        ReligionName = record.ReligionMaster?.ReligionName
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

        public CasteMasterResponse? Update(CasteMasterRequest request)
        {
            try
            {
                var existingRecord = dbContext.CasteMasters
                    .Include(inc => inc.ReligionMaster)
                    .FirstOrDefault(whr => whr.CasteId == request.CasteId);

                if (existingRecord != null)
                {
                    existingRecord.CasteName = request.CasteName;
                    existingRecord.ReligionIdRef = request.ReligionIdRef;

                    dbContext.CasteMasters.Update(existingRecord);
                    dbContext.SaveChanges();

                    var response = new CasteMasterResponse
                    {
                        CasteId = existingRecord.CasteId,
                        CasteName = existingRecord.CasteName,
                        ReligionIdRef = existingRecord.ReligionIdRef,
                        ReligionName = existingRecord.ReligionMaster?.ReligionName
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

        private CasteMaster? IsCasteExistByName(string? casteName)
        {
            var existingRecord = dbContext.CasteMasters
                .FirstOrDefault(whr => whr.CasteName.ToLower() == casteName.ToLower());

            return existingRecord;
        }
    }
}
