using Games.Contaxt.Database;
using GamesRep.Repositry;
using GamesUI.Components;
using GamsIRep.IRepositry;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextPool<GamesContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("GamesConnection")));
builder.Services.AddScoped<IVenueRep, VenueRep>();
builder.Services.AddScoped<IRoomRep, RoomRep>();
builder.Services.AddScoped<IGameRep, GameRep>();
builder.Services.AddScoped<IUseRep, UserRep>();
builder.Services.AddScoped<IBookingRep, BookingRep>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
