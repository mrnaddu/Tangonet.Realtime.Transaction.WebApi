using Tangonet.Realtime.Transaction.WebApi.Helpers;
using Tangonet.Realtime.Transaction.WebApi.Interfaces;
using Tangonet.Realtime.Transaction.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddAutoMapper(typeof(Program));

// Dependency Injection
builder.Services.AddScoped<ITransactionAppService, TransactionAppService>();
builder.Services.AddScoped<ConnectionHelper>();

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
