//////////////////////////
// generated Program.cs //
//////////////////////////
using Serilog;
using Application;
using Persistence;
using WebMVC.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    // Read from your appsettings.json.
    .AddJsonFile("appsettings.json")
    // Read from your secrets.
    //.AddUserSecrets<Program>(optional: true)
    //.AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

// added these for this project
builder.Services.AddPersistence();
builder.Services.AddApplication();

//this is needed for Serilog.AspNetCore, Serilog.Settings.Configuration, Serilog.Sinks.File, Serilog.Sinks.Console,Serilog.Expressions
//installed in application project,
//this project has reference to application project
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
builder.Host.UseSerilog();

//this is need for exception handling
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

//added to handle exceptions
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
