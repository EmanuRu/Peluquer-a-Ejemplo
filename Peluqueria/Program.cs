using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Aplicacion.CasosDeUso.Cliente.Commands.CuAgregarCliente;
using Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuListarClientes;
using Peluqueria.Aplicacion.IRepository.IProfesional;
using Peluqueria.Aplicacion.IRepository.IClientes;
using Peluqueria.Aplicacion.IRepository.IServicio;
using Peluqueria.Data;
using Peluqueria.Aplicacion.Data;
using Peluqueria.Infraestructura.Data;
using Peluqueria.Infraestructura.Repository.Cliente;
using Peluqueria.Aplicacion.CasosDeUso.Profesionales.Commands.CuAgregarProfesional;
using Peluqueria.Infraestructura.Repository.Profesionales;
using Peluqueria.Aplicacion.CasosDeUso.Profesionales.Querys.CuListarProfesional;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Querys.CuListarServicios;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuAgregarServicio;
using Peluqueria.Infraestructura.Repository.Servicios;
using Peluqueria.Infraestructura.Repository.Servicio;
using Peluqueria.Infraestructura.Repository.Clientes;
using Peluqueria.Aplicacion.IRepository.IEstadoReserva;
using Peluqueria.Infraestructura.Repository.EstadoReserva;
using Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Commands.CuAgregarEstadoRes;
using Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Querys.CuListarEstadoRes;
using Peluqueria.Aplicacion.IRepository.IReserva;
using Peluqueria.Infraestructura.Repository.Reservas;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuListarReservas;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuAgregarReserva;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));//conxion con la BD

// Registro de AutoMapper y MediatR
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IClienteCommandRepository, ClienteCommandRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AgregarCli).Assembly));

builder.Services.AddScoped<IClienteQueryRepository, ClienteQueryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListarCliente).Assembly));


builder.Services.AddScoped<IProfesionalCommandRepository, ProfesionalCommandRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AgregarProf).Assembly));

builder.Services.AddScoped<IProfesionalQueryRepository, ProfesionalQueryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListarProf).Assembly));

builder.Services.AddScoped<IServicioCommandRepository, ServicioCommandRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AgregarServ).Assembly));

builder.Services.AddScoped<IServicioQueryRepository, ServicioQueryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListarServicio).Assembly));

builder.Services.AddScoped<IEstadoReservaCommandRepository, EstadoReservaCommandRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AgregarERes).Assembly));

builder.Services.AddScoped<IEstadoReservaQueryRepository, EstadoReservaQueryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListarEstadoRes).Assembly));

builder.Services.AddScoped<IReservaCommandRepository, ReservaCommandRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AgregarReser).Assembly));

builder.Services.AddScoped<IReservaQueryRepository, ReservasQueryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListarReserv).Assembly));

var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];
builder.Services.AddHttpClient("PeluqueriaAPI", httpClient =>
{
    httpClient.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllers();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
