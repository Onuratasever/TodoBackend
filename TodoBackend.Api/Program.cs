using TodoBackend.Persistence;
using TodoBackend.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(builder.Configuration); //This parameter will be passed to the AddPersistenceServices function
builder.Services.AddApplication(); //This function will add the application services to the DI container

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
//todo change this cors later

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors();
app.MapControllers(); //This function will add the routing for the controllers 
app.Run();
