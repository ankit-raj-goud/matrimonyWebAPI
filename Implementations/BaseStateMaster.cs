using MatrimonyWebApi.Data;
using MatrimonyWebApi.Models;
using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MatrimonyWebApi.Implementations
{
    public class BaseStateMaster : IStateRepository
    {
        private readonly MatrimonyDbContext dbContext;

        public BaseStateMaster(MatrimonyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public StateMasterResponse? Create(StateMasterRequest request)
        {
            try
            {
                if(request != null)
                {
                    var existingStateByName = IsStateExist(request.CountryId, request.StateName);
                    if (existingStateByName != null)
                    {
                        throw new BadHttpRequestException("State already exists !!");
                    }

                    var newRecord = new StateMaster 
                    {
                        StateName = request.StateName,
                        CountryIdRef  = request.CountryId,
                    };

                    dbContext.StateMasters.Add(newRecord);
                    dbContext.SaveChanges();

                    newRecord = dbContext.StateMasters
                        .Include(inc => inc.Country)
                        .FirstOrDefault(whr => whr.StateId == newRecord.StateId);

                    //response
                    var response = new StateMasterResponse
                    {
                        StateId = newRecord.StateId,
                        StateName = newRecord.StateName,
                        CountryId = newRecord.CountryIdRef,
                        CountryName = newRecord.Country?.CountryName
                    };

                    return response;
                }
                else
                {
                    throw new InvalidDataException("invalid request !!");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public StateMasterResponse? Delete(int id)
        {
            try
            {
                var existingRecord = dbContext.StateMasters.Include(inc => inc.Country).FirstOrDefault(whr => whr.StateId == id);

                if (existingRecord != null)
                {
                    dbContext.StateMasters.Remove(existingRecord);
                    dbContext.SaveChanges();

                    //response
                    var response = new StateMasterResponse
                    {
                        StateId = existingRecord.StateId,
                        StateName = existingRecord.StateName,
                        CountryId = existingRecord.CountryIdRef,
                        CountryName = existingRecord.Country?.CountryName
                    };

                    return response;
                }
                else
                {
                    throw new KeyNotFoundException("no data found");
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public List<StateMasterResponse> GetAll()
        {
            try
            {
                var dataList = dbContext.StateMasters.Include(inc => inc.Country).ToList();

                var responseList = new List<StateMasterResponse>();

                foreach (var data in dataList) 
                {
                    var response = new StateMasterResponse
                    {
                        StateId = data.StateId,
                        StateName = data.StateName,
                        CountryId = data.CountryIdRef,
                        CountryName = data.Country?.CountryName    
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

        public StateMasterResponse? GetById(int id)
        {
            try
            {
                var data = dbContext.StateMasters.FirstOrDefault(whr => whr.StateId == id);

                if (data != null)
                {
                    //response
                    var response = new StateMasterResponse
                    {
                        StateId = data.StateId,
                        StateName = data.StateName,
                        CountryId = data.CountryIdRef,
                        CountryName = data.Country?.CountryName
                    };

                    return response;
                }
                else
                {
                    throw new KeyNotFoundException("no data found !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public StateMasterResponse? Update(StateMasterRequest request)
        {
            try
            {
                var existingRecord = dbContext.StateMasters.FirstOrDefault(whr => whr.StateId == request.StateId);

                if (existingRecord != null)
                {
                    var existingStateByName = IsStateExist(request.CountryId, request.StateName);
                    if (existingStateByName != null)
                    {
                        throw new BadHttpRequestException("State already exists !!");
                    }

                    existingRecord.StateName = request.StateName;
                    existingRecord.CountryIdRef = request.CountryId;
                    
                    dbContext.StateMasters.Update(existingRecord);
                    dbContext.SaveChanges();

                    existingRecord = dbContext.StateMasters
                        .Include(inc => inc.Country)
                        .FirstOrDefault(existingRecord);

                    //response
                    var response = new StateMasterResponse
                    {
                        StateId = existingRecord.StateId,
                        StateName = existingRecord.StateName,
                        CountryId = existingRecord.CountryIdRef,
                        CountryName = existingRecord.Country?.CountryName
                    };

                    return response;
                }
                else
                {
                    throw new KeyNotFoundException("no data found !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private StateMaster? IsStateExist(int countyrId, string stateName)
        {
            try
            {
                var existingState = dbContext.StateMasters
                    .FirstOrDefault(whr => whr.StateName.ToLower() == stateName.ToLower());
                
                
                return existingState;
                                
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
