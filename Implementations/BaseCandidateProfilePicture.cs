using MatrimonyWebApi.Data;
using MatrimonyWebApi.Models;
using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MatrimonyWebApi.Implementations
{
    public class BaseCandidateProfilePicture : ICandidatePictureRepository
    {
        private readonly MatrimonyDbContext dbContext;
        private readonly IWebHostEnvironment environment;

        public string baseUrl;

        public BaseCandidateProfilePicture(MatrimonyDbContext dbContext, IWebHostEnvironment environment)
        {
            this.dbContext = dbContext;
            this.environment = environment;

            this.baseUrl = Path.Combine(this.environment.WebRootPath, "UserUploads");
        }

        public async Task<CandidatePictureResponse> DeleteProfilePicture(int pictureId)
        {
            try
            {
                var dataList = await GetCandidateProfilePicture(pictureId, null);

                if (dataList != null) 
                {
                    var existingRecord = dataList.First();

                    dbContext.Remove(existingRecord);
                    await dbContext.SaveChangesAsync();

                    //delete picture from folder
                    string baseUrl = Path.Combine(environment.WebRootPath, "UserUploads");

                    string filePath = Path.Combine(baseUrl, existingRecord.PictureId.ToString() + existingRecord.PictureType);

                    if(File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    
                    var response = GenerateResponse(existingRecord);

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

        public async Task<CandidatePictureResponse> SaveProfilePicture(CandidatePictureRequest pictureRequest)
        {
            try
            {
                var candidateId = pictureRequest.CandidateId;
                var existingRecord = await GetCandidateProfilePicture(null, candidateId);
                
                if(existingRecord != null && existingRecord.Count >= 10)
                {
                    throw new BadHttpRequestException("only 10 picutres are allowed, please delete some pictures !!");
                }
                else
                {
                    //save picture record in db
                    var newRecord = new CandidateProfilePicture
                    {
                        CandidateIdRef = candidateId,
                        PictureType = Path.GetExtension(pictureRequest.FileDetails.FileName),
                        UpdateDate = DateTime.Now
                    };

                    dbContext.Add(newRecord);
                    await dbContext.SaveChangesAsync();

                    //save picture to folder
                    string baseUrl = Path.Combine(environment.WebRootPath, "UserUploads");

                    string filePath = Path.Combine(baseUrl, newRecord.PictureId.ToString() + newRecord.PictureType);

                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await pictureRequest.FileDetails.CopyToAsync(fileStream);
                    }

                    //return response
                    var response = GenerateResponse(newRecord); 
                    return response;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CandidatePictureResponse> UpdateProfilePicture(CandidatePictureRequest pictureRequest)
        {
            try
            {
                var existingRecord = await GetCandidateProfilePicture(pictureRequest.PictureId, null);

                if(existingRecord != null && existingRecord.Count > 0)
                {
                    //delete existing db record
                    var record = existingRecord.First();

                    dbContext.CandidateProfilePictures.Remove(record);
                    await dbContext.SaveChangesAsync();

                    //save new picture record in db
                    var newRecord = new CandidateProfilePicture
                    {
                        CandidateIdRef = pictureRequest.CandidateId,
                        PictureType = Path.GetExtension(pictureRequest.FileDetails.FileName),
                        UpdateDate = DateTime.Now
                    };

                    dbContext.Add(newRecord);
                    await dbContext.SaveChangesAsync();

                    //save picture to folder
                    string baseUrl = Path.Combine(environment.WebRootPath, "UserUploads");

                    string filePath = Path.Combine(baseUrl, newRecord.PictureId.ToString() + newRecord.PictureType);

                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await pictureRequest.FileDetails.CopyToAsync(fileStream);
                    }

                    //return response
                    var response = GenerateResponse(newRecord);
                    return response;
                }
                else
                {
                    throw new BadHttpRequestException("no record found !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<List<CandidateProfilePicture>?> GetCandidateProfilePicture(int? pictureId = null, Guid? candidateId = null)
        {
            try
            {
                var query = dbContext.CandidateProfilePictures
                    .Include(inc => inc.Candidate)
                    .AsQueryable();

                if(pictureId != null)
                {
                    query = query.Where(whr => whr.PictureId == pictureId);
                }

                if(candidateId != null)
                {
                    query = query.Where(whr => whr.CandidateIdRef == candidateId);
                }

                var profilePictureList = await query.ToListAsync();

                return profilePictureList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private CandidatePictureResponse GenerateResponse(CandidateProfilePicture profilePicture)
        {
            try
            {
                var response = new CandidatePictureResponse
                {
                    PictureId = profilePicture.PictureId,
                    PictureUrl = Path.Combine(baseUrl, 
                                        profilePicture.PictureId.ToString() + profilePicture.PictureType)
                                        ?? string.Empty,
                    CandidateId = profilePicture.CandidateIdRef
                };

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CandidatePictureResponse>> GetProfilePicture(Guid candidateId)
        {
            try
            {
                var recordList = await GetCandidateProfilePicture(null, candidateId);

                var responseList = new List<CandidatePictureResponse>();

                foreach (var record in recordList)
                {
                    var response = GenerateResponse(record);
                    responseList.Add(response);                
                }

                return responseList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
