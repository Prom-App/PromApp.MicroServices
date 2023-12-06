using PromApp.Mensajeria.Dominio.Entidades.Email;
using PromApp.Mensajeria.Infraestructura;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection("GmailSettings"));
builder.Services.AgregarDependenciasInfra(builder.Configuration);

builder.Services.AddControllers();
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