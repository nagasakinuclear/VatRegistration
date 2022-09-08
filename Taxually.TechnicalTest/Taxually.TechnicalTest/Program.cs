using AutoMapper;
using Taxually.TechnicalTest.AppLogic;
using Taxually.TechnicalTest.DataAccess;
using Taxually.TechnicalTest.DataAccess.Clients;
using Taxually.TechnicalTest.DataAccess.Clients.Contracts;
using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess;
using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts;
using Taxually.TechnicalTest.Web.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new VatRegistrationProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IVatRegistrationRepository, VatRegistrationRepository>();
builder.Services.AddSingleton<IVatRegistrationFactory, VatRegistrationFactory>();

// It is better to read countries from db and assign strategies by code, but for now I'm going to hardcode it
builder.Services.AddSingleton<IVatRegistrationFactoryConfiguration>(
    new VatRegistrationFactoryConfiguration(
        new Dictionary<string, Type>()
        {
            { "GB", typeof(IVatRegistrationJsonStrategy) },
            { "FR", typeof(IVatRegistrationCsvStrategy) },
            { "DE", typeof(IVatRegistrationXmlStrategy) },
        })
    );

builder.Services.AddTransient<IVatRegistrationXmlStrategy, VatRegistrationXmlStrategy>();
builder.Services.AddTransient<IVatRegistrationJsonStrategy, VatRegistrationJsonStrategy>();
builder.Services.AddTransient<IVatRegistrationCsvStrategy, VatRegistrationCsvStrategy>();

builder.Services.AddTransient<ITaxuallyQueueClient, TaxuallyQueueClient>();
builder.Services.AddTransient<ITaxuallyHttpClient, TaxuallyHttpClient>();

builder.Services.AddTransient<IVatRegistrationService, VatRegistrationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
