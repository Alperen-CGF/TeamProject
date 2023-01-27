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
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<IRoleDal,EfRoleDal>();
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
