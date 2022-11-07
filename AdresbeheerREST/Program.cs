using AdresbeheerBL.Interfaces;
using AdresbeheerBL.Services;
using AdresbeheerDL.Repositories;

var builder = WebApplication.CreateBuilder(args);
string connectionString = @"Data Source=FRENK\SQLEXPRESS;Initial Catalog=AdresBeheerREST;Integrated Security=True";
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IGemeenteRepository>(r =>new GemeenteRepositoryADO(connectionString));
builder.Services.AddSingleton<IStraatRepository>(r => new StraatRepositoryADO(connectionString));
builder.Services.AddSingleton<GemeenteService>();
builder.Services.AddSingleton<straatService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
