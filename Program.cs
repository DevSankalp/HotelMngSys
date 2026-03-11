using HotelManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// determine which connection string to use; default to empty if not set
string mode = builder.Configuration["DatabaseMode"] ?? string.Empty;

// GetConnectionString expects a non-null name, so use empty string if mode is missing
string? conn = builder.Configuration.GetConnectionString(mode);

builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(conn));

builder.Services.AddRazorPages();

builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapRazorPages();

app.Run();
