using System.Net.WebSockets;
using WebApiDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapRazorPages());

app.MapControllers();

//var db = UserContext.GetInstance();
//db.Users.Add(new User() { Name = "Ivan", Age = 21, Email = "Ivan@gmoil.net" });
//db.SaveChanges();
//var list = db.Users.ToList();

app.UseDefaultFiles("/page.razor");

app.Run();

