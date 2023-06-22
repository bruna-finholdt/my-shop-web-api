var builder = WebApplication.CreateBuilder(args);

string connectionString = "Server=.\\SQLExpress;Database=IterisLoja;Trusted_Connection=True;TrustServerCertificate=True;";

// Add services to the container.

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



//conceito database first

//comando: Scaffold-DbContext "Server=.\\SQLExpress;Database=IterisLoja;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Domain\Entity" -ContextDir DAL
//comando para gerar as entidades na pasta Domain.Entity (as pastas são criadas sozinhas) e
//gerar a classe de DbContext na pasta DAL (que tb é criada sozinha com o comando)


