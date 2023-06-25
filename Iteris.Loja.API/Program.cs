using Iteris.Loja.API.DAL;
using Microsoft.EntityFrameworkCore;
using Iteris.Loja.API.DAL.Repositories;
using Iteris.Loja.API.Services;

var builder = WebApplication.CreateBuilder(args);

//Dps que coloquei a connectionString no appsettings.json, comentei o código abaixo
//string connectionString = "Server=.\\SQLExpress;Database=IterisLoja;Trusted_Connection=True;TrustServerCertificate=True;";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injetando repositórios: AddScoped - Uma nova instância por request
builder.Services.AddScoped<CustomersRepository>();
builder.Services.AddScoped<OrderItemsRepository>();
builder.Services.AddScoped<OrdersRepository>();
builder.Services.AddScoped<ProductsRepository>();

// Injetando repositórios: AddScoped - Uma nova instância cada vez que necessário
builder.Services.AddTransient<CustomersService>();
builder.Services.AddTransient<PurchasesService>();
builder.Services.AddTransient<ProductsService>();

//códigos acima para adicionar a injeção de dependência das classes CustomersRepository, OrderItemsRepository,
//OrdersRepository e ProductsRepository como scoped e CustomersService e PurchaseService como transient. 

// Recupera DefaultConnection da sessão de connections strings do arquivo appsettings.json
//e adiciona o IterisLojaContext na injeção de dependência. 
//Classe de contexto na injeção de dependência do projeto;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IterisLojaContext>(options => options.UseSqlServer(connectionString));

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

//comando: Scaffold-DbContext "Server=.\SQLExpress;Database=IterisLoja;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Domain\Entity" -ContextDir DAL
//obs: colocar uma "\" só (conforme coment acima)...não precisa das 2 nesse comando
//comando para gerar as entidades na pasta Domain.Entity (as pastas são criadas sozinhas) e
//gerar a classe de DbContext na pasta DAL (que tb é criada sozinha com o comando)


