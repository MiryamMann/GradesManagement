
using GradeDAL.Configurations;
using GradeDAL.Services;
using GradeDO;
using GradesProject.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IStudents, Students>();
builder.Services.AddScoped<IGradeManager, GradeManager>();
builder.Services.AddScoped<IPasswordManager, PasswordManager>();
builder.Services.Configure<List<GradePercent>>(builder.Configuration.GetSection("Grades"));
builder.Services.Configure<Teacher>(builder.Configuration.GetSection("Teacher"));
builder.Services.AddControllers();

string logPath = builder.Configuration["Logging:LogFilePath"];
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss}][{Level}] ~~ {Message:lj} {NewLine}")
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} - {Message:lj}{NewLine}{Exception}") // Log to file
    .CreateLogger();
builder.Host.UseSerilog();

builder.Logging.AddConsole();
builder.Logging.AddDebug();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseExceptionHandler("/error");
app.MapControllers();

app.Run();
