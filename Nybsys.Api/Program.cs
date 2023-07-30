using ApplicationService;
using DatabaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nybsys.Api;
using Nybsys.DataAccess.Contracts2;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NybsysDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddTransient<IEmployeeTRepository, EmployeeRepositoryT>();
//builder.Services.AddTransient<IDesignationRepository, DesignationRepository>();
//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p =>p.AddPolicy("corsplicy",build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysecret.....")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew=TimeSpan.Zero

    };
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsplicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
