using Microsoft.Azure.Cosmos;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Load configuration
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>(true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();

//Configure CosmosDB client
builder.Services.AddScoped<CosmosClient>(_ =>
{
    const string connectionStringName = "DOCDBCONNSTR_CosmosDbConnection";
    
    var connectionString = builder.Configuration[connectionStringName]
        ?? throw new ConfigurationErrorsException($"\"{connectionStringName}\" environment variable/user secret was not set correctly.");

    return new CosmosClient(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
