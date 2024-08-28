using TranslateService.DI;
using TranslateService.DI.CashServices;
using TranslateService.DI.TranslateServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ICashService, VirtualCashService>();
builder.Services.AddTransient<ITranslateService, YandexTranslateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
