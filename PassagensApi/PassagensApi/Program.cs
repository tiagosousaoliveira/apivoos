using Microsoft.Extensions.DependencyInjection;
using PassagensInfra;
using PassagensServices;
using PassagensServices.mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddServices();
builder.Services.AddMediatR( x => x.RegisterServicesFromAssemblyContaining<ObtemPassagensQuery>());
builder.Services.AddAutoMapper(typeof(CiaAereaPrfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
