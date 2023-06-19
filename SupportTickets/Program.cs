using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SupportTickets.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



var name = Environment.GetEnvironmentVariable("DATABASENAME");
var user = Environment.GetEnvironmentVariable("DATABASEUSER");
var password = Environment.GetEnvironmentVariable("DATABASEPASSWORD");
var host = Environment.GetEnvironmentVariable("DATABASEHOST");
var port = Environment.GetEnvironmentVariable("DATABASEPORT");
var connectionString = $"User ID={user};Password={password};Host={host};Port={port};Database={name};";
Console.WriteLine(connectionString);
builder.Services.AddDbContext<TicketDBContext>(options =>
    options.UseNpgsql(connectionString));
var tempbuilder = new DbContextOptionsBuilder<TicketDBContext>();
tempbuilder.UseNpgsql(connectionString);
var tempdb = new TicketDBContext(tempbuilder.Options);
await tempdb.Database.MigrateAsync();


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
