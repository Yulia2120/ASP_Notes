using ASP_Notes.Models;
using ASP_Notes.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//работа с NotesAPIDbContext

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<NotesAPIDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<NotesAPIDbContext>();
builder.Services.AddScoped<NoteRepository>();
//builder.Services.AddScoped<SeedData>();

//сопоставляем блок JWTSettings из файла конфигурации с моделью (для выдачи токена) 

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
//секретные фразы, которые знает только сервер
var secretKey = builder.Configuration.GetSection("JWTSettings:SecretKey").Value;
var issuer = builder.Configuration.GetSection("JWTSettings:Issuer").Value;
var audience = builder.Configuration.GetSection("JWTSettings:Audience").Value;
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

//устанавливаем аутентификацию с помощью токенов, указав одну схему аутентификации

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
//задаем параметры валидации токена. Указываем, что нужно проверять издателя, потребителя, ключ и срок действия токена
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateLifetime = true,
        IssuerSigningKey = signingKey,
        ValidateIssuerSigningKey = true,
        //ClockSkew = TimeSpan.Zero, убрать дефолтное время жизни токена
        LifetimeValidator = CustomLifetime.CustomLifetimeValidator


    };
});


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
//добавляем компонент в конвейер промежуточного ПО
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
