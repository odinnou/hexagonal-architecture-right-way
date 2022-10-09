using Service.DrivenAdapters.DatabaseAdapters.Configuration;
using Service.DrivingAdapters.Configuration;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// 1. Configuration binding step

ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
AppSettings appSettings = new();
configuration.GetSection(nameof(AppSettings)).Bind(appSettings);

// 2. Add services step

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddUseCases();
builder.Services.AddThirdParties(appSettings);
builder.Services.AddAutoMapper(Assembly.Load(typeof(Program).Assembly.GetName().Name!));
builder.Services.AddDatabase(appSettings.DatabaseConnection);

// 3. Use services step

WebApplication app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// 4. Application startup step

app.Run();