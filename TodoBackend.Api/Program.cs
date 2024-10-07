using TodoBackend;
using TodoBackend.Persistence;
using TodoBackend.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(builder.Configuration); //This parameter will be passed to the AddPersistenceServices function
builder.Services.AddApplication(); //This function will add the application services to the DI container

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
//todo change this cors later

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningCustom();
builder.Services.AddEndpoints(typeof(Program).Assembly);
// builder.Services.AddControllers(); 
builder.Services.AddSwaggerGen();

var app = builder.Build();

var versionedGroup = app.CreateVersionedRouteGroup();

app.MapEndpoints(versionedGroup);

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
// app.MapControllers(); //This function will add the routing for the controllers 
app.Run();
