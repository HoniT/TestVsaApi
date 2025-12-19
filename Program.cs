using Microsoft.EntityFrameworkCore;
using src.Features;
using src.Features.Employees.Add;
using src.Features.Employees.Delete;
using src.Features.Employees.GetAll;
using src.Features.Employees.Update;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<GetAllEmployeesHandler>();
builder.Services.AddScoped<AddEmployeeHandler>();
builder.Services.AddScoped<UpdateEmployeeHandler>();
builder.Services.AddScoped<DeleteEmployeeHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

GetAllEmployeesEndpoint.Map(app);
AddEmployeeEndpoint.Map(app);
UpdateEmployeeEndpoint.Map(app);
DeleteEmployeeEndpoint.Map(app);

app.UseHttpsRedirection();

app.Run();

