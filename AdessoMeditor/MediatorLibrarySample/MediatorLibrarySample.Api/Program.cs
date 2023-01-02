using MediatorLibrarySample.CQRS;
using MediatorLibrarySample.CQRS.Processor;
using MediatorLibrarySample.Domain.Repository;
using MediatorLibrarySample.Repository;
using MediatorLibrarySample.Repository.Repository;
using MediatorLibrarySample.Application.MoneyTransfer;
using MediatorLibrarySample.Application.MoneyTransfer.Command.CreateMoneyTransfer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IMoneyTransferRepository, MoneyTransferRepository>();

builder.Services.AddAdessoMeditor(AppDomain.CurrentDomain.Load("MediatorLibrarySample.Application"));



builder.Services.AddScoped(typeof(IAdessoRequestPreProcessor<>), typeof(MyTestPreProcessor<>));
builder.Services.AddScoped(typeof(IAdessoRequestPostProcessor<,>), typeof(MyTestPostProcessor<,>));



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
