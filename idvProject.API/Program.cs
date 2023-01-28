using idvProject.Business.Abstract;
using idvProject.Business.Concrete;
using idvProject.DataAccess.Abstract;
using idvProject.DataAccess.Concrete;
using idvProject.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
