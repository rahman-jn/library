using System.Text;
using Entities;
using Extensions;
using libraryapi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration
var config = builder.Configuration;

// AuthHelper
builder.Services.AddSingleton<AuthHelper>();

// Connect to SQL Server database
var connectionString = config.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,               // Maximum number of retry attempts
            maxRetryDelay: TimeSpan.FromSeconds(30),  // Max delay between retries
            errorNumbersToAdd: null);        // SQL error numbers to trigger a retry
    }));

// Configure repository wrapper
builder.Services.ConfigureRepositoryWrapper();

// AutoMapper configuration
builder.Services.AddAutoMapper(typeof(Program));

// JWT configuration
builder.Services.AddAuthentication(cfg => {
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true; // SaveToken to true in case you want to reuse the token in subsequent requests.
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Auth:JWT_Secret"])),
        ValidateIssuer = false, // Change to true if you want to validate the issuer
        ValidateAudience = false, // Change to true if you want to validate the audience
        ValidateLifetime = true, // Ensure token hasn't expired
        ClockSkew = TimeSpan.Zero // Optional: Set ClockSkew to zero to avoid time drift issues
    };
});

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// CORS Configuration (Optional, depending on Angular)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Angular's development server
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<SecurityMiddleware>();

// Enforce HTTPS in production
app.UseHttpsRedirection();

// Use CORS if needed
app.UseCors("AllowAngularApp");

// Authentication and Authorization
app.UseRouting();
app.UseAuthentication(); // Ensure this is before UseAuthorization
app.UseAuthorization();

app.MapControllers();
app.Run();
