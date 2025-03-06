using ChatServer.Data;
using ChatServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});
builder.Services.AddSingleton<ShareDb>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/Chat");
app.UseCors("ReactApp");

app.Run();
