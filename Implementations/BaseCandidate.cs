using Azure.Core;
using MatrimonyWebApi.Data;
using MatrimonyWebApi.Models;
using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net;

namespace MatrimonyWebApi.Implementations
{
    public class BaseCandidate : ICandidateRepository
    {
        private readonly MatrimonyDbContext dbContext;

        public BaseCandidate(MatrimonyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public CandidateResponse? Create(CandidateRequest request)
        {
            try
            {
                var newRecord = new Candidate
                {
                    CandidateId = Guid.NewGuid(),
                    Name = request.Name,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    Address = request.Address,
                    SubCaste = request.SubCaste,
                    FatherName = request.FatherName,
                    MotherName = request.MotherName,
                    FamilyType = request.FamilyType,
                    FamilyIncome = request.FamilyIncome,
                    IsProfilePictureOpenVisible = request.IsProfilePictureOpenVisible,
                    Description = request.Description,
                    DesiredPartnerDescription = request.DesiredPartnerDescription,
                    ContactPerson = request.ContactPerson,
                    ContactNumber = request.ContactNumber,
                    IsContactNumberOpen = request.IsContactNumberOpen,
                    Height = request.Height,
                    Weight = request.Weight,
                    Color = request.Color,
                    Profession = request.Profession,
                    PersonalMonthlyIncome = request.PersonalMonthlyIncome,
                    CityIdRef = request.CityIdRef,
                    CasteIdRef = request.CasteIdRef,
                    GenderIdRef = request.GenderIdRef
                };

                dbContext.Candidates.Add(newRecord);
                dbContext.SaveChanges();

                newRecord = GetCandidate(newRecord.CandidateId);

                var response = GetCandidateResponse(newRecord);

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CandidateResponse? Delete(Guid id)
        {
            try
            {
                var existingRecord = GetCandidate(id);

                if (existingRecord != null)
                {
                    var response = GetCandidateResponse(existingRecord);

                    dbContext.Candidates.Remove(existingRecord);
                    dbContext.SaveChanges();
                    
                    return response;
                }
                else
                {
                    throw new BadHttpRequestException("invalid id !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CandidateResponse> GetAll()
        {
            try
            {
                var dataList = dbContext.Candidates.ToList();

                var responseList = new List<CandidateResponse>();

                foreach (var data in dataList)
                {
                    var response = GetCandidateResponse(data);

                    responseList.Add(response);
                }

                return responseList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CandidateResponse? GetById(Guid id)
        {
            try
            {
                var record = GetCandidate(id);

                if (record != null)
                {
                    var response = GetCandidateResponse(record);

                    return response;
                }
                else
                {
                    throw new BadHttpRequestException("invalid id");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CandidateResponse? Update(CandidateRequest request)
        {
            try
            {
                var existingRecord = GetCandidate(request.CandidateId);

                if(existingRecord != null)
                {
                    existingRecord.Name = request.Name;
                    existingRecord.MiddleName = request.MiddleName;
                    existingRecord.LastName = request.LastName;
                    existingRecord.Address = request.Address;
                    existingRecord.SubCaste = request.SubCaste;
                    existingRecord.FatherName = request.FatherName;
                    existingRecord.MotherName = request.MotherName;
                    existingRecord.FamilyType = request.FamilyType;
                    existingRecord.FamilyIncome = request.FamilyIncome;
                    existingRecord.IsProfilePictureOpenVisible = request.IsProfilePictureOpenVisible;
                    existingRecord.Description = request.Description;
                    existingRecord.DesiredPartnerDescription = request.DesiredPartnerDescription;
                    existingRecord.ContactPerson = request.ContactPerson;
                    existingRecord.ContactNumber = request.ContactNumber;
                    existingRecord.IsContactNumberOpen = request.IsContactNumberOpen;
                    existingRecord.Height = request.Height;
                    existingRecord.Weight = request.Weight;
                    existingRecord.Color = request.Color;
                    existingRecord.Profession = request.Profession;
                    existingRecord.PersonalMonthlyIncome = request.PersonalMonthlyIncome;
                    existingRecord.CityIdRef = request.CityIdRef;
                    existingRecord.CasteIdRef = request.CasteIdRef;
                    existingRecord.GenderIdRef = request.GenderIdRef;

                    dbContext.Candidates.Update(existingRecord);
                    dbContext.SaveChanges();

                    var response = GetCandidateResponse(existingRecord);

                    return response;
                }
                else
                {
                    throw new BadHttpRequestException("invalid id");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Candidate? GetCandidate(Guid id)
        {
            try
            {
                var record = dbContext.Candidates
                    .FirstOrDefault(whr => whr.CandidateId == id);

                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Candidate? GetCandidateByContactNumber(string contactNumber)
        {
            try
            {
                var record = dbContext.Candidates
                    .Include(inc => inc.CasteMaster)
                    .Include(inc => inc.CityMaster)
                    .Include(inc => inc.GenderMaster)
                    .FirstOrDefault(whr => whr.ContactNumber == contactNumber);

                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private CandidateResponse? GetCandidateResponse(Candidate data)
        {            
            if (data != null)
            {
                var response = new CandidateResponse
                {
                    CandidateId = data.CandidateId,
                    Name = data.Name,
                    MiddleName = data.MiddleName,
                    LastName = data.LastName,
                    Address = data.Address,
                    SubCaste = data.SubCaste,
                    FatherName = data.FatherName,
                    MotherName = data.MotherName,
                    FamilyType = data.FamilyType,
                    FamilyIncome = data.FamilyIncome,
                    IsProfilePictureOpenVisible = data.IsProfilePictureOpenVisible,
                    Description = data.Description,
                    DesiredPartnerDescription = data.DesiredPartnerDescription,
                    ContactPerson = data.ContactPerson,
                    ContactNumber = data.ContactNumber,
                    IsContactNumberOpen = data.IsContactNumberOpen,
                    Height = data.Height,
                    Weight = data.Weight,
                    Color = data.Color,
                    Profession = data.Profession,
                    PersonalMonthlyIncome = data.PersonalMonthlyIncome,
                    CityIdRef = data.CityIdRef,
                    CasteIdRef = data.CasteIdRef,
                    GenderIdRef = data.GenderIdRef,
                    CasteName = data.CasteMaster?.CasteName ?? string.Empty,
                    CityName = data.CityMaster?.CityName ?? string.Empty,
                    GenderName = data.GenderMaster?.Gender ?? string.Empty,
                };

                return response;
            }
            else
            {
                return null;
            }
        }

    }
}
