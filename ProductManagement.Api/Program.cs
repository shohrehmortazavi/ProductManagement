using Microsoft.OpenApi.Models;
using ProductManagement.Api.SeedWorks;
using ProductManagement.Infrastructure.Data;
using ProductManagement.Infrastructure.SeedWorks;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<Guid>(() => new OpenApiSchema { Type = "string", Format = "uuid" });
});


builder.Services.AddDbContext(builder.Configuration)
                .AddRepositories()
                .Addservices(builder.Configuration);

var app = builder.Build();

app.EnsureMigrationOfContext<ProductManagmentDbContext>();

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
