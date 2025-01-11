using Microsoft.EntityFrameworkCore;
using Shedule.Data;
using Serilog;
using System.Globalization;
using Shedule.Services;
using AltairCA.Blazor.WebAssembly.Cookie.Framework;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.CreateLogger();

try
{
	var builder = WebApplication.CreateBuilder(args);

	// Add services to the container.
	builder.Services.AddRazorPages();
	builder.Services.AddServerSideBlazor();
	builder.Services.AddScoped<IManager, SqliteManagersAsync>();
    builder.Services.AddScoped<ICity, SqliteCityAsync>();
    builder.Services.AddScoped<ICustomer, SqliteCustomersAsync>();
    builder.Services.AddScoped<ISeller, SqliteSellersAsync>();
    builder.Services.AddScoped<IPaymentEvent, SqlitePaymentEventsAsync>();
	builder.Services.AddScoped<ISaleEvent, SqliteSaleEventsAsync> ();
	builder.Services.AddSingleton<Week>();
	builder.Services.AddSingleton<UsersStatus>();
	builder.Services.AddScoped<ICookie, Cookie>();

	builder.Host.ConfigureLogging(logging =>
	{
		logging.AddSerilog();
		logging.SetMinimumLevel(LogLevel.Information);
	})
	.UseSerilog();

	builder.Services.AddLocalization();

	var dbPath = "base.db";
	builder.Services.AddDbContext<AppDbContext>(
	   options => options.UseSqlite($"Data Source={dbPath}"));

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler("/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	}

	app.UseHttpsRedirection();

	app.UseStaticFiles();

	app.UseRouting();

	app.MapBlazorHub();
	app.MapFallbackToPage("/_Host");

	app.Run();
}

catch (Exception ex)
{
	Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
	Log.CloseAndFlush();
}
