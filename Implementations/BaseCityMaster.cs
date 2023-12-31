using MatrimonyWebApi.Data;
using MatrimonyWebApi.Models;
using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MatrimonyWebApi.Implementations
{
    public class BaseCityMaster : ICityRepository
    {
        private readonly MatrimonyDbContext dbContext;

        public BaseCityMaster(MatrimonyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public CityMasterResponse? Create(CityMasterRequest request)
        {
            try
            {
                if (request != null)
                {
                    var existingCityByName = IsCityExist(request.StateId, request.CityName);
                    if (existingCityByName != null)
                    {
                        throw new BadHttpRequestException("State already exists !!");
                    }

                    var newRecord = new CityMaster
                    {
                        CityName = request.CityName,
                        StateIdRef = request.StateId,
                    };

                    dbContext.CityMasters.Add(newRecord);
                    dbContext.SaveChanges();

                    //response
                    var response = new CityMasterResponse
                    {
                        StateId = newRecord.StateIdRef,
                        StateName = newRecord.StateMaster?.StateName,
                        CityId = newRecord.CityId,
                        CityName = newRecord.CityName,
                        CountryId = newRecord.StateMaster?.Country?.CountryId,
                        CountryName = newRecord.StateMaster?.Country?.CountryName
                    };

                    return response;
                }
                else
                {
                    throw new BadHttpRequestException("invalid request !!");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CityMasterResponse? Delete(int id)
        {
            try
            {
                var existingRecord = dbContext.CityMasters
                    .Include(inc => inc.StateMaster)
                    .Include(inc => inc.StateMaster.Country)
                    .FirstOrDefault(whr => whr.CityId == id);

                if (existingRecord != null)
                {
                    dbContext.CityMasters.Remove(existingRecord);
                    dbContext.SaveChanges();

                    //response
                    var response = new CityMasterResponse
                    {
                        StateId = existingRecord.StateIdRef,
                        StateName = existingRecord.StateMaster?.StateName,
                        CityId = existingRecord.CityId,
                        CityName = existingRecord.CityName,
                        CountryId = existingRecord.StateMaster?.Country?.CountryId,
                        CountryName = existingRecord.StateMaster?.Country?.CountryName
                    };

                    return response;
                }
                else
                {
                    throw new BadHttpRequestException("no data found");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CityMasterResponse> GetAll()
        {
            try
            {
                var dataList = dbContext.CityMasters
                    .Include(inc => inc.StateMaster)
                    .Include(inc => inc.StateMaster.Country)
                    .ToList();

                var responseList = new List<CityMasterResponse>();

                foreach (var data in dataList)
                {
                    var response = new CityMasterResponse
                    {
                        StateId = data.StateIdRef,
                        StateName = data.StateMaster?.StateName,
                        CityId = data.CityId,
                        CityName = data.CityName,
                        CountryId = data.StateMaster?.Country?.CountryId,
                        CountryName = data.StateMaster?.Country?.CountryName
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

        public CityMasterResponse? GetById(int id)
        {
            try
            {
                var data = dbContext.CityMasters
                    .Include(inc => inc.StateMaster)
                    .Include(inc => inc.StateMaster.Country)
                    .FirstOrDefault(whr => whr.CityId == id);

                if (data != null)
                {
                    //response
                    var response = new CityMasterResponse
                    {
                        StateId = data.StateIdRef,
                        StateName = data.StateMaster?.StateName,
                        CityId = data.CityId,
                        CityName = data.CityName,
                        CountryId = data.StateMaster?.Country?.CountryId,
                        CountryName = data.StateMaster?.Country?.CountryName
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

        public CityMasterResponse? Update(CityMasterRequest request)
        {
            try
            {
                var existingRecord = dbContext.CityMasters.FirstOrDefault(whr => whr.CityId == request.CityId);

                if (existingRecord != null)
                {
                    var existingCityByName = IsCityExist(request.StateId, request.CityName);
                    if (existingCityByName != null)
                    {
                        throw new BadHttpRequestException("City already exists !!");
                    }

                    existingRecord.CityName = request.CityName;
                    existingRecord.StateIdRef = request.StateId;

                    dbContext.CityMasters.Update(existingRecord);
                    dbContext.SaveChanges();

                    //response
                    var response = new CityMasterResponse
                    {
                        StateId = existingRecord.StateIdRef,
                        StateName = existingRecord.StateMaster?.StateName,
                        CityId = existingRecord.CityId,
                        CityName = existingRecord.CityName
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

        private CityMaster? IsCityExist(int stateId, string cityName)
        {
            try
            {
                var existingCity = dbContext.CityMasters
                    .FirstOrDefault(whr => whr.CityName.ToLower() == cityName.ToLower());


                return existingCity;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
