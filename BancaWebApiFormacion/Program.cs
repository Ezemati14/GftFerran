using AutoMapper;
using Banca.Data.Repository.Commands;
using Banca.Data.Repository.Queries;
using Banca.Infrastructure.Context;
using Banca.Services.Commands;
using Banca.Services.Profiles;
using Banca.Services.Queries;
using Banca.Services.Validaciones;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DI
builder.Services.AddTransient<IValidacionService, ValidacionService>();
builder.Services.AddTransient<ICreateDepositoCommand, CreateDepositoCommand>();
builder.Services.AddTransient<IDeleteDepositoCommand, DeleteDepositoCommand>();
builder.Services.AddTransient<IGetDepositoQuery, GetDepositoQuery>();
builder.Services.AddTransient<IDepositoRepository, DepositoRepository>();
builder.Services.AddTransient<IDepositoQuery, DepositoQuery>();

//Add Automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var mapperConfig = new MapperConfiguration(mapperConfiguration =>
{
    mapperConfiguration.AddProfile(new DepositoProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//Add DB 
builder.Services.AddDbContext<AppBancaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BD_Banca"));
}
);

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
