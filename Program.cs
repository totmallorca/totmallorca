using mallorca.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

app.UseStaticFiles();

app.MapRazorPages();
app.MapHub<ChatHub>("/chathub");

app.Run();
