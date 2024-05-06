using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using rfm.srv.kitdevnet.domain.interfaces.input;
using rfm.srv.kitdevnet.domain.interfaces.output;
using rfm.srv.kitdevnet.output.mongo.commons;
using rfm.srv.kitdevnet.output.mongo.Registro;
using rfm.srv.kitdevnet.output.sqlserver.dapper.Registro;
using rfm.srv.kitdevnet.output.sqlserver.ef.commons;
using rfm.srv.kitdevnet.output.sqlserver.ef.Item;
using rfm.srv.kitdevnet.service.Item;
using rfm.srv.kitdevnet.service.Produto;
using rfm.srv.kitdevnet.service.Registro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependencias
builder.Services.AddScoped<IItemUserCase, ItemServices>();
builder.Services.AddScoped<IProdutoUserCase, ProdutoServices>();
builder.Services.AddScoped<IRegistroUserCase, RegistroServices>();

builder.Services.AddScoped<IItemPort, ItemPersistence>();
builder.Services.AddScoped<IProdutoPort, ProdutoPersistence>();
builder.Services.AddScoped<IRegistroPort, RegistroPersistence>();

// Strings de Conexão com database SqlServer
var stringConexao = builder.Configuration.GetConnectionString("KitDevNetSqlServer");
builder.Services.AddScoped<IDbConnection>((_) => new SqlConnection(stringConexao));
builder.Services.AddDbContext<EFSqlServerContext>(options => options.UseSqlServer(stringConexao));

// Parametros database Mongo
var mongoSettings = builder.Configuration.GetSection("KitDevNetMongoDatabase").Get<KitDevNetDatabaseSettings>();
builder.Services.AddSingleton<KitDevNetDatabaseSettings>(mongoSettings);

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
