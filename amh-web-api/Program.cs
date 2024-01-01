using AccessData;
using amh_web_api.DTO;
using Domain.Models.GestorExpedientes;
using Domain.Models.GestorGastos;
using Domain.Models.MayiBeerCollection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Application.DTO.General;
using Application.Interfaces.General.IServices;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Services.General;
using AccessData.Commands.General;
using AccessData.Query.General;
using Application.Interfaces.GestorExpedientes.IServices;
using Application.Interfaces.GestorExpedientes.ICommands;
using Application.Interfaces.GestorExpedientes.IQueries;
using Application.Services.GestorExpedientes;
using AccessData.Commands.GestorExpedientes;
using AccessData.Query.GestorExpedientes;
using Application.Interfaces.GestorGastos.IServices;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Services.GestorGastos;
using AccessData.Commands.GestorGastos;
using AccessData.Query.GestorGastos;
using Application.Interfaces.MayiBeerCollection.IServices;
using Application.Interfaces.MayiBeerCollection.ICommands;
using Application.Interfaces.MayiBeerCollection.IQueries;
using Application.Services.MayiBeerCollection;
using AccessData.Commands.MayiBeerCollection;
using AccessData.Query.MayiBeerCollection;
using Application.DTO.MayiBeerCollection;
using Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

//ADD MAPERS
builder.Services.AddAutoMapper(config =>
{
    #region GENERAL
    config.CreateMap<Ciudad, CiudadResponse>();
    config.CreateMap<CiudadResponse, Ciudad>();

    config.CreateMap<Ciudad, CiudadPaisResponse>();
    config.CreateMap<CiudadPaisResponse, Ciudad>();

    config.CreateMap<Ciudad, CiudadRequest>();
    config.CreateMap<CiudadRequest, Ciudad>();

    config.CreateMap<Sistema, SistemaResponse>();
    config.CreateMap<SistemaResponse, Sistema>();

    config.CreateMap<Sistema, SistemaRequest>();
    config.CreateMap<SistemaRequest, Sistema>();

    config.CreateMap<Usuario, UsuarioResponse>();
    config.CreateMap<UsuarioResponse, Usuario>();

    config.CreateMap<Usuario, UsuarioRequest>();
    config.CreateMap<UsuarioRequest, Usuario>();

    config.CreateMap<Usuario, UsuarioLoginDTO>();
    config.CreateMap<UsuarioLoginDTO, Usuario>();

    config.CreateMap<UsuarioSistema, UsuarioSistemaResponse>();
    config.CreateMap<UsuarioSistemaResponse, UsuarioSistema>();

    config.CreateMap<UsuarioSistema, UsuarioSistemaRequest>();
    config.CreateMap<UsuarioSistemaRequest, UsuarioSistema>();

    config.CreateMap<Pais, PaisRequest>();
    config.CreateMap<PaisRequest, Pais>();

    config.CreateMap<Pais, PaisResponse>();
    config.CreateMap<PaisResponse, Pais>();

    config.CreateMap<Pais, PaisCiudadResponse>();
    config.CreateMap<PaisCiudadResponse, Pais>();
    #endregion
      
    #region MAYIBEERCOLLECTION
    config.CreateMap<Cerveza, CervezaRequest>();
    config.CreateMap<CervezaRequest, Cerveza>();

    config.CreateMap<Estilo, EstiloRequest>();
    config.CreateMap<EstiloRequest, Estilo>();

    config.CreateMap<Marca, MarcaRequest>();
    config.CreateMap<MarcaRequest, Marca>();

    config.CreateMap<Cerveza, CervezaResponse>();
    config.CreateMap<CervezaResponse, Cerveza>();

    config.CreateMap<Estilo, EstiloResponse>();
    config.CreateMap<EstiloResponse, Estilo>();

    config.CreateMap<Marca, MarcaResponse>();
    config.CreateMap<MarcaResponse, Marca>(); 
    #endregion

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

//ADD CORS
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONNECTION STRING
builder.Services.AddDbContext<AmhWebDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<AmhWebDbContext>(x => x.UseSqlServer("Data Source=SQL5097.site4now.net;Initial Catalog=db_a934ba_mayibeercollection;User Id=db_a934ba_mayibeercollection_admin;Password=Caslacapo1908**"));
//var connectionString = builder.Configuration["ConnectionString"];
//builder.Services.AddDbContext<AmhWebDbContext>(options => options.UseSqlServer(connectionString));


//INTERFACES
#region General
builder.Services.AddTransient<ICiudadService, CiudadService>();
builder.Services.AddTransient<IPaisService, PaisService>();
builder.Services.AddTransient<ISistemaService, SistemaService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IUsuarioSistemaService, UsuarioSistemaService>();
builder.Services.AddTransient<ITokenServices, TokenServices>();

builder.Services.AddTransient<ICiudadQuery, CiudadQuery>();
builder.Services.AddTransient<IPaisQuery, PaisQuery>();
builder.Services.AddTransient<ISistemaQuery, SistemaQuery>();
builder.Services.AddTransient<IUsuarioQuery, UsuarioQuery>();
builder.Services.AddTransient<IUsuarioSistemaQuery, UsuarioSistemaQuery>();

builder.Services.AddTransient<ICiudadCommand, CiudadCommand>();
builder.Services.AddTransient<IPaisCommand, PaisCommand>();
builder.Services.AddTransient<ISistemaCommand, SistemaCommand>();
builder.Services.AddTransient<IUsuarioCommand, UsuarioCommand>();
builder.Services.AddTransient<IUsuarioSistemaCommand, UsuarioSistemaCommand>();

builder.Services.AddHttpClient<IServerImagesApiService, ServerImagesApiService>()
       .Services.AddScoped<IServerImagesApiService, ServerImagesApiService>();
#endregion

#region GestorExpedientes
builder.Services.AddTransient<IActoService, ActoService>();
builder.Services.AddTransient<ICaratulaService, CaratulaService>();
builder.Services.AddTransient<IExpedienteService, ExpedienteService>();
builder.Services.AddTransient<ISituacionRevistaService, SituacionRevistaService>();

builder.Services.AddTransient<IActoQuery, ActoQuery>();
builder.Services.AddTransient<ICaratulaQuery, CaratulaQuery>();
builder.Services.AddTransient<IExpedienteQuery, ExpedienteQuery>();
builder.Services.AddTransient<ISituacionRevistaQuery, SituacionRevistaQuery>();

builder.Services.AddTransient<IActoCommand, ActoCommand>();
builder.Services.AddTransient<ICaratulaCommand, CaratulaCommand>();
builder.Services.AddTransient<IExpedienteCommand, ExpedienteCommand>();
builder.Services.AddTransient<ISituacionRevistaCommand, SituacionRevistaCommand>();
#endregion

#region GestorGastos
builder.Services.AddTransient<IBancoService, BancoService>();
builder.Services.AddTransient<ICuentaService, CuentaService>();
builder.Services.AddTransient<IEmpresaService, EmpresaService>();
builder.Services.AddTransient<IRegistroService, RegistroService>();
builder.Services.AddTransient<IRegistroVinculadoService, RegistroVinculadoService>();
builder.Services.AddTransient<ISuscripcionService, SuscripcionService>();
builder.Services.AddTransient<ITarjetaService, TarjetaService>();
builder.Services.AddTransient<ITipoCuentaService, TipoCuentaService>();
builder.Services.AddTransient<ITipoTarjetaService, TipoTarjetaService>();

builder.Services.AddTransient<IBancoQuery, BancoQuery>();
builder.Services.AddTransient<ICuentaQuery, CuentaQuery>();
builder.Services.AddTransient<IEmpresaQuery, EmpresaQuery>();
builder.Services.AddTransient<IRegistroQuery, RegistroQuery>();
builder.Services.AddTransient<IRegistroVinculadoQuery, RegistroVinculadoQuery>();
builder.Services.AddTransient<ISuscripcionQuery, SuscripcionQuery>();
builder.Services.AddTransient<ITarjetaQuery, TarjetaQuery>();
builder.Services.AddTransient<ITipoCuentaQuery, TipoCuentaQuery>();
builder.Services.AddTransient<ITipoTarjetaQuery, TipoTarjetaQuery>();

builder.Services.AddTransient<IBancoCommand, BancoCommand>();
builder.Services.AddTransient<ICuentaCommand, CuentaCommand>();
builder.Services.AddTransient<IEmpresaCommand, EmpresaCommand>();
builder.Services.AddTransient<IRegistroCommand, RegistroCommand>();
builder.Services.AddTransient<IRegistroVinculadoCommand, RegistroVinculadoCommand>();
builder.Services.AddTransient<ISuscripcionCommand, SuscripcionCommand>();
builder.Services.AddTransient<ITarjetaCommand, TarjetaCommand>();
builder.Services.AddTransient<ITipoCuentaCommand, TipoCuentaCommand>();
builder.Services.AddTransient<ITipoTarjetaCommand, TipoTarjetaCommand>();
#endregion

#region MayiBeerCollection
builder.Services.AddTransient<ICervezaService, CervezaService>();
builder.Services.AddTransient<IEstiloService, EstiloService>();
builder.Services.AddTransient<IMarcaService, MarcaService>();

builder.Services.AddTransient<ICervezaQuery, CervezaQuery>();
builder.Services.AddTransient<IEstiloQuery, EstiloQuery>();
builder.Services.AddTransient<IMarcaQuery, MarcaQuery>();

builder.Services.AddTransient<ICervezaCommand, CervezaCommand>();
builder.Services.AddTransient<IEstiloCommand, EstiloCommand>();
builder.Services.AddTransient<IMarcaCommand, MarcaCommand>();
#endregion


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
