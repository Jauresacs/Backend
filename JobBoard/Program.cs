using JobBoard.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext with MySQL configuration
builder.Services.AddDbContext<JobBoardContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 23)) // Spécifie la version du serveur MySQL
    ));

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5500", "http://127.0.0.1:5500") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});


// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:5027", // Mon émetteur de token
            ValidAudience = "http://localhost:5527", // Mon audience qui doit recevoir le token.
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("t8Zul9YJGeGTuXcApJnphyMsqpI8mfht")) // Ma clé secrète.
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable CORS
app.UseCors("AllowLocalhost");

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
