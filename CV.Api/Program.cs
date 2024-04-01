using AspNetCoreRateLimit;
using CV.Api.Mapping;
using CV.Application;
using CV.Application.Database;
using CV.Application.Services.ApiKeyService;
using CV_backend.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Minimal API",
        Version = "v1"
    });
});
//builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddRateLimiting(builder.Configuration);

var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
Console.WriteLine(connectionString);
builder.Services.AddDatabase(connectionString);

var blobService = new BlobService();
await blobService.UploadTextToBlobAsync(connectionString, "connectionstringslogs", "testblob.txt");


var jwtTokenSecret = Environment.GetEnvironmentVariable("JWT_TOKEN_SECRET");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenSecret)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        ValidateIssuer = true,
        ValidateAudience = true,
    };

    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = async context =>
        {
            var apiKeyService = context.HttpContext.RequestServices.GetRequiredService<IApiKeyService>();

            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            // Check if the header is null or doesn't start with "Bearer "
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                context.Fail("Authorization header is missing or not in Bearer token format.");
                return;
            }

            // Extract the token from the header
            var apiKeyHeaderValue = authorizationHeader.Substring("Bearer ".Length).Trim();

            if (string.IsNullOrWhiteSpace(apiKeyHeaderValue))
            {
                context.Fail("API Key is required");
                return;
            }

            var isRevoked = await apiKeyService.IsApiKeyRevoked(apiKeyHeaderValue);
            if (isRevoked)
            {
                context.Fail("API Key is revoked");
                return;
            }

        }
    };
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIpRateLimiting(); 


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ValidationMappingMiddleware>();

app.MapControllers();

var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();

app.Run();
