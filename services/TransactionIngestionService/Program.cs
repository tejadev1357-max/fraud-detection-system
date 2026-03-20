using TransactionIngestionService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ruleEngineBaseUrl = builder.Configuration.GetValue<string>("RuleEngine:BaseUrl") ?? "http://localhost:5001";
builder.Services.AddHttpClient<ITransactionService, TransactionService>(client =>
{
    client.BaseAddress = new Uri(ruleEngineBaseUrl);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
