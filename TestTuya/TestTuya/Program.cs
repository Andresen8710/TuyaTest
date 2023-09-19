using Microsoft.EntityFrameworkCore;
using TestTuya.AppServices;
using TestTuya.AppServices.Contracts;
using TestTuya.DomainServices;
using TestTuya.DomainServices.Contracts;
using TestTuya.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", options =>
    {
        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

//JSon Serializar
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                                                                      = new Newtonsoft.Json.Serialization.DefaultContractResolver());
// omitir nulos en las respuestas del Json
builder.Services.AddControllers().AddJsonOptions(Options => Options.JsonSerializerOptions.DefaultIgnoreCondition
                    = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);

//Context
builder.Services.AddDbContext<TestTuyaIContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("database")));

builder.Services.AddScoped<IAppServices, AppServices>();
builder.Services.AddScoped<IDomainServices, DomainServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
