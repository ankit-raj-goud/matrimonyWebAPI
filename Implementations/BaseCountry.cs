using MatrimonyWebApi.Data;
using MatrimonyWebApi.Models;
using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MatrimonyWebApi.Implementations
{
    public class BaseCountry : ICountryRepository
    {
        private readonly MatrimonyDbContext dbContext;

        public BaseCountry(MatrimonyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CountryResponse Create(CountryRequest request)
        {
            try
            {
                if (request.CountryName != null && request.CountryName.Length != 0)
                {
                    var data = new CountryMaster
                    {                        
                        CountryName = request.CountryName
                    };

                    dbContext.Country.Add(data);
                    dbContext.SaveChanges();

                    return new CountryResponse
                    {
                        CountryId = data.CountryId,
                        CountryName = data.CountryName
                    };
                }
                else
                {
                    throw new Exception("invalid request");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CountryResponse? Delete(int id)
        {
            try
            {
                var existingRecord = dbContext.Country.FirstOrDefault(whr => whr.CountryId == id);

                if (existingRecord != null)
                {
                    var response = new CountryResponse
                    {
                        CountryId = existingRecord.CountryId,
                        CountryName = existingRecord.CountryName
                    };

                    dbContext.Country.Remove(existingRecord);
                    dbContext.SaveChanges();

                    return response;
                }
                else
                {
                    throw new KeyNotFoundException("invalid id");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CountryResponse>> GetAll()
        {
            try
            {
                var data = await dbContext.Country.ToListAsync();

                var countryList = new List<CountryResponse>();

                foreach ( var country in data) 
                {
                    countryList.Add(new CountryResponse
                    {
                        CountryId = country.CountryId,
                        CountryName = country.CountryName,
                    });
                }

                return countryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CountryResponse GetById(int id)
        {
            try
            {
                var data = dbContext.Country.FirstOrDefault(whr => whr.CountryId == id);

                if(data != null)
                {
                    var response = new CountryResponse
                    {
                        CountryId = data.CountryId,
                        CountryName = data.CountryName
                    }; 
                    return response;
                }
                else
                {
                    throw new Exception("no data found");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public CountryResponse? Update(CountryRequest request)
        {
            try
            {
                var existingRecord = dbContext.Country.FirstOrDefault(whr => whr.CountryId == request.CountryId);

                if(existingRecord != null)
                {
                    existingRecord.CountryName = request.CountryName;

                    dbContext.SaveChanges();

                    var response = new CountryResponse
                    {
                        CountryId = existingRecord.CountryId,
                        CountryName = existingRecord.CountryName,
                    };

                    return response;
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
