using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Core.Services;
using CDEUnileverAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CDEUnileverDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CDEUnilever")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

///
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IAreaService), typeof(AreaService));
builder.Services.AddTransient(typeof(ITitleService), typeof(TitleService));

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
