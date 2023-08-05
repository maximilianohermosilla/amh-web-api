using AccessData;
using amh_web_api.DTO;
using Domain.Models.GestorExpedientes;
using Domain.Models.GestorGastos;
using Domain.Models.MayiBeerCollection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//ADD MAPERS
builder.Services.AddAutoMapper(config =>
{
    //GENERAL
    config.CreateMap<Sistema, SistemaDTO>();
    config.CreateMap<SistemaDTO, Sistema>();

    config.CreateMap<Usuario, UsuarioDTO>();
    config.CreateMap<UsuarioDTO, Usuario>();

    config.CreateMap<Usuario, UsuarioLoginDTO>();
    config.CreateMap<UsuarioLoginDTO, Usuario>();

    config.CreateMap<UsuarioSistema, UsuarioSistemaDTO>();
    config.CreateMap<UsuarioSistemaDTO, UsuarioSistema>();

    config.CreateMap<Pais, PaisDTO>();
    config.CreateMap<PaisDTO, Pais>();

    //MAYIBEERCOLLECTION
    config.CreateMap<Cerveza, CervezaDTO>();
    config.CreateMap<CervezaDTO, Cerveza>();

    config.CreateMap<Ciudad, CiudadDTO>();
    config.CreateMap<CiudadDTO, Ciudad>();

    config.CreateMap<Estilo, EstiloDTO>();
    config.CreateMap<EstiloDTO, Estilo>();

    config.CreateMap<Marca, MarcaDTO>();
    config.CreateMap<MarcaDTO, Marca>();

    //GESTOR EXPEDIENTES
    config.CreateMap<Expediente, ExpedienteDTO>();
    config.CreateMap<ExpedienteDTO, Expediente>();

    //GESTOR GASTOS
    config.CreateMap<Tarjeta, TarjetaDTO>();
    config.CreateMap<TarjetaDTO, Tarjeta>();

    config.CreateMap<Cuenta, CuentaDTO>();
    config.CreateMap<CuentaDTO, Cuenta>();

    config.CreateMap<Registro, RegistroDTO>();
    config.CreateMap<RegistroDTO, Registro>();

}, typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONNECTION STRING
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AmhWebDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//USE CORS
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
