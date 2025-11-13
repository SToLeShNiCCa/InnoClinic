using Infrastructure.DbSettings;
using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using Presentation.Extensions;
using Infrastructure.Extension;
using Application.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation(builder.Configuration);
builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();

builder.Services.Configure<MongoDatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.Configure<AzureDatabaseSettings>(builder.Configuration.GetSection("BlobStorage"));

builder.Services.AddSingleton(_ => new BlobServiceClient("UseDevelopmentStorage=true"));

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["StorageConnection:blobServiceUri"]!).WithName("StorageConnection");
});

var app = builder.Build();

app.UseApplicationSettings(builder.Environment);

app.MapControllers();

app.Run();