using Presentation.Extensions;
using Infrastructure.Extension;
using Application.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o => 
    {
        o.RequireHttpsMetadata = false;
        o.Audience = builder.Configuration["Authentication:Audience"];
        o.MetadataAddress = builder.Configuration["Authentication:MetadataAddress"]!;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Authentication:ValidIssuer"]
        };
    });

builder.Services.AddPresentation(builder.Configuration, builder.Configuration);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

var app = builder.Build();

app.UseApplicationSettings(builder.Environment);

app.MapControllers();

app.Run();