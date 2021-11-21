using Microsoft.AspNetCore.Mvc.Formatters;
using Packt.Shared;
using static System.Console;
using Northwind.WebApi.Repositories;
using Microsoft.AspNetCore.HttpLogging; // HttpLoggingFields

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:5002/");
// Add services to the container.
builder.Services.AddControllers(options =>
{
  WriteLine("Default output formatters");
  foreach (IOutputFormatter formatter in options.OutputFormatters)
  {
    OutputFormatter? mediaFormatter = formatter as OutputFormatter;
    if (mediaFormatter == null)
    {
      WriteLine($"{formatter.GetType().Name}");
    }
    else // Output formatter class has SupportedMediaTypes
    {
      WriteLine("{0}, Media types: {1}",
          arg0: mediaFormatter.GetType().Name,
          arg1: string.Join(", ", mediaFormatter.SupportedMediaTypes));
    }
  }
})
.AddXmlDataContractSerializerFormatters()
.AddXmlSerializerFormatters();

builder.Services.AddNorthwindContext();
// Swagger
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new() { Title = "Northwind.WebApi", Version = "v1" });
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddHttpLogging(options =>
{
  options.LoggingFields = HttpLoggingFields.All;
  options.RequestBodyLogLimit = 4096; // default is 32k
  options.ResponseBodyLogLimit = 4096; // default is 32k
});

builder.Services.AddCors();

builder.Services.AddHealthChecks()
  .AddDbContextCheck<NorthwindContext>();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseCors(configurePolicy: options =>
{
  options.WithMethods("GET", "POST", "PUT", "DELETE");
  options.WithOrigins(
    "https://localhost:5001" // allow requests from the MVC client
  );
});


app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind.WebApi v1"));
}

app.UseHttpsRedirection();

app.UseHealthChecks(path: "/howdoyoufeel");

app.UseAuthorization();

app.UseMiddleware<SecurityHeaders>();

app.MapControllers();

app.Run();

