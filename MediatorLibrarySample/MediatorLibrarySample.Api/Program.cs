using MediatorLibrarySample.CQRS;
using MediatorLibrarySample.Domain.Repository;
using MediatorLibrarySample.Repository;
using MediatorLibrarySample.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IMoneyTransferRepository, MoneyTransferRepository>();

builder.Services.AddAdessoMeditor(AppDomain.CurrentDomain.Load("MediatorLibrarySample.Application"));

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
