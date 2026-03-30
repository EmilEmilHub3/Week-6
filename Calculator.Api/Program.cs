var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();