using Presentation.Extensions;
using Infrastructure.Extension;
using Application.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation(builder.Configuration, builder.Configuration);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

var app = builder.Build();

app.UseApplicationSettings(builder.Environment);

app.MapControllers();

app.Run();