using SignalRDemo.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCors(options => { options.AddPolicy("CorsPolicy", builder => { builder.WithOrigins("https://localhost:7074").AllowAnyHeader().AllowAnyMethod().AllowCredentials(); }); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseAuthorization();

// client huba ba�lanmak i�in myhub urlini kullans�n
app.MapHub<MyHub>("/myhub");

app.MapControllers();

app.Run();
