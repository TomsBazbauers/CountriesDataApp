using CountriesDataApp.Core.AutoMapper;
using CountriesDataApp.Core.Filters.EUCountries;
using CountriesDataApp.Core.Filters.Interfaces;
using CountriesDataApp.Core.Helpers.Interfaces;
using CountriesDataApp.Core.Helpers.Sort;
using CountriesDataApp.Services.Data.IDataServiceEU;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers();
builder.Services
    .AddEndpointsApiExplorer();
builder.Services
    .AddSwaggerGen();

builder.Services
    .AddRefitClient<IDataServiceEU>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://restcountries.com/"));

builder.Services
    .AddScoped<ICountryDataFilterEU, CountryDataFilterEU>();

builder.Services
    .AddScoped<ICountryDataSorter, CountryDataSorter>();

builder.Services
    .AddSingleton(AutoMapperConfig.CreateMapper());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
