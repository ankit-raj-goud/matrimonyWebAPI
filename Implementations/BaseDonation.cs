using MatrimonyWebApi.Data;
using MatrimonyWebApi.Models;
using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MatrimonyWebApi.Implementations
{
    public class BaseDonation : IDonationRepository
    {
        private readonly MatrimonyDbContext dbContext;

        public BaseDonation(MatrimonyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DonationResponse? Create(DonationRequest request)
        {
            try
            {
                var newRecord = new Donation
                {
                    DonerName = request.DonerName,
                    Address = request.Address,
                    Amount = request.Amount,
                    CityIdRef = request.CityId,
                    Description = request.Description
                };

                dbContext.Donations.Add(newRecord);
                dbContext.SaveChanges();

                newRecord = GetDonationRecord(newRecord.DonationId);

                var response = new DonationResponse
                {
                    DonationId = newRecord.DonationId,
                    Address = newRecord.Address,
                    Amount = newRecord.Amount,
                    CityId = newRecord.CityIdRef,
                    Description = newRecord.Description,
                    CityName = newRecord.CityMaster?.CityName,
                    DonerName = newRecord.DonerName
                };

                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DonationResponse? Delete(int id)
        {
            try
            {
                var existingRecord = GetDonationRecord(id);

                if(existingRecord != null)
                {
                    dbContext.Donations.Remove(existingRecord);
                    dbContext.SaveChanges();

                    var response = new DonationResponse
                    {
                        DonationId = existingRecord.DonationId,
                        Address = existingRecord.Address,
                        Amount = existingRecord.Amount,
                        CityId = existingRecord.CityIdRef,
                        Description = existingRecord.Description,
                        CityName = existingRecord.CityMaster?.CityName,
                        DonerName = existingRecord.DonerName
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

        public List<DonationResponse> GetAll()
        {
            try
            {
                var dataList = dbContext.Donations.Include(inc => inc.CityMaster).ToList();
                var responseList = new List<DonationResponse>();

                foreach (var data in dataList)
                {
                    var response = new DonationResponse
                    {
                        DonationId = data.DonationId,
                        Address = data.Address,
                        Amount = data.Amount,
                        CityId = data.CityIdRef,
                        CityName = data.CityMaster?.CityName,
                        Description = data.Description,
                        DonerName = data.DonerName
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

        public DonationResponse? GetById(int id)
        {
            try
            {
                var responseData = GetDonationRecord(id);

                if(responseData != null)
                {
                    var response = new DonationResponse
                    {
                        DonationId = responseData.DonationId,
                        Address = responseData.Address,
                        Amount = responseData.Amount,
                        CityId = responseData.CityIdRef,
                        Description = responseData.Description,
                        CityName = responseData.CityMaster?.CityName,
                        DonerName = responseData.DonerName
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

        public DonationResponse? Update(DonationRequest request)
        {
            try
            {
                var existingRecord = GetDonationRecord(request.DonationId);

                if(existingRecord != null) 
                {
                    existingRecord.DonerName = request.DonerName;
                    existingRecord.Amount = request.Amount;
                    existingRecord.Address = request.Address;
                    existingRecord.CityIdRef = request.CityId;
                    existingRecord.Description = request.Description;

                    dbContext.Donations.Update(existingRecord);
                    dbContext.SaveChanges();

                    existingRecord = GetDonationRecord(request.DonationId);

                    var response = new DonationResponse
                    {
                        DonationId = existingRecord.DonationId,
                        Address = existingRecord.Address,
                        Amount = existingRecord.Amount,
                        CityId = existingRecord.CityIdRef,
                        Description = existingRecord.Description,
                        CityName = existingRecord.CityMaster?.CityName,
                        DonerName = existingRecord.DonerName
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

        private Donation? GetDonationRecord(int id)
        {
            try
            {
                var responseData = dbContext.Donations
                    .Include(inc => inc.CityMaster)
                    .FirstOrDefault(whr => whr.DonationId == id);

                return responseData;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
