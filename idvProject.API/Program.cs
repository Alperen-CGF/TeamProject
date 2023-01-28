using idvProject.Business.Abstract;
using idvProject.Business.Concrete;
using idvProject.DataAccess.Abstract;
using idvProject.DataAccess.Concrete;
using idvProject.DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description ="Standart Authorization header using the Bearer scheme(\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey=true,
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer =false,
            ValidateAudience =false,
        };
    });
    
builder.Services.AddScoped<IActorService, ActorManager>();
builder.Services.AddScoped<IActorDal, EfActorDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IMovieActorService, MovieActorManager>();
builder.Services.AddScoped<IMovieActorDal, EfMovieActorDal>();
builder.Services.AddScoped<IMovieService, MovieManager>();
builder.Services.AddScoped<IMovieDal, EfMovieDal>();
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<IRoleDal,EfRoleDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IUserRoleService, UserRoleManager>();
builder.Services.AddScoped<IUserRoleDal, EfUserRoleDal>();

//builder.Services.AddDbContext<DataBaseContext>(opts =>
//{
//    opts.UseSqlServer(@"Server=DESKTOP-J7U6SM8;Database=IDVDB;Trusted_Connection=true;trustServerCertificate=true");
//    //opts.UseLazyLoadingProxies();   
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
