using ExpensesManagementApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<Context>(options => 
    options.UseMySql(connection, Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(connection)));

var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "ExpensesManagementApi.Profiles");
foreach(var p in profiles)
{
    builder.Services.AddAutoMapper(p);
}

var services = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "ExpensesManagementApi.Services");
foreach (var s in services)
{
    builder.Services.AddScoped(s);
}

var repositories = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "ExpensesManagementApi.Repositories");
foreach (var r in repositories)
{
    builder.Services.AddScoped(r);
}

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
