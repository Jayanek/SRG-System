using Microsoft.Azure.Cosmos;
using Microsoft.Net.Http.Headers;
using SRG_SYSTEM.Repository;
using WebApiContrib.Core.Formatter.Protobuf;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();



builder.Services.AddControllers(options =>
{
    options.FormatterMappings
        .SetMediaTypeMappingForFormat("protobuf",
          MediaTypeHeaderValue.Parse("application/x-protobuf"));
}).AddProtobufFormatters();


builder.Services.AddSingleton<IPageCosmosService>(options =>
{
    string url = builder.Configuration.GetSection("CosmosDbSettings")
    .GetValue<string>("AccountURL");
    string primaryKey = builder.Configuration.GetSection("CosmosDbSettings")
    .GetValue<string>("AuthKey");
    string dbName = builder.Configuration.GetSection("CosmosDbSettings")
    .GetValue<string>("DatabaseId");
    string containerName = builder.Configuration.GetSection("CosmosDbSettings")
    .GetValue<string>("ContainerName");

    var cosmosClient = new CosmosClient(
        url,
        primaryKey
    );

    return new PageCosmosService(cosmosClient, dbName, containerName);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
