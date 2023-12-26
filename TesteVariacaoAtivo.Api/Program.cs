using Microsoft.EntityFrameworkCore;
using Refit;
using TesteVariacaoAtivo.Application.Integration.Interfaces;
using TesteVariacaoAtivo.Application.Integration.Refit;
using TesteVariacaoAtivo.Application.Integration.Services;
using TesteVariacaoAtivo.Application.Internal.Interfaces;
using TesteVariacaoAtivo.Application.Internal.Services;
using TesteVariacaoAtivo.Domain.Interfaces.Repository;
using TesteVariacaoAtivo.Infra.Data;
using TesteVariacaoAtivo.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<TestAssetContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionBD")));

builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IFinanceYahooIntegration, FinanceYahooIntegrationService>();
builder.Services.AddScoped<IAssetService, AssetService>();

//Refit Integration
builder.Services.AddRefitClient<IFinanceYahooIntegrationRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://query1.finance.yahoo.com/v8");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapControllers();
app.Run();
