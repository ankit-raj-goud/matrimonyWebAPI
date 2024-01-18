using MatrimonyWebApi.Data;
using MatrimonyWebApi.Implementations;
using MatrimonyWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding connection string
builder.Services.AddDbContext<MatrimonyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MatrimonyConnectionString")));

//repository implementations
builder.Services.AddScoped<ICountryRepository, BaseCountry>();
builder.Services.AddScoped<IStateRepository, BaseStateMaster>();
builder.Services.AddScoped<ICityRepository, BaseCityMaster>();
builder.Services.AddScoped<IReligionRepository, BaseReligionMaster>();
builder.Services.AddScoped<ICasteRepository, BaseCasteMaster>();
builder.Services.AddScoped<IDonationRepository, BaseDonation>();
builder.Services.AddScoped<ICandidateRepository, BaseCandidate>();
builder.Services.AddScoped<IInterestRepository, BaseInterest>();
builder.Services.AddScoped<ICandidatePictureRepository, BaseCandidateProfilePicture>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
