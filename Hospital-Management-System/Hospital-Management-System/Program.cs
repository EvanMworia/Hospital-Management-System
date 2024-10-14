using Hospital_Management_System.Data;
using Hospital_Management_System.Services;
using Hospital_Management_System.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//-------------1. REGISTERING DB CONTEXT TO THE DI CONTAINER
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

//-------------2. REGISTERING AUTOMAPPER--------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//-------------3. REGISTERING OUR SERVICE INTERFACE
builder.Services.AddScoped<IPatient, PatientServices>();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
