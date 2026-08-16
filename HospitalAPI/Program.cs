using HospitalAPI.Data;
using HospitalAPI.Person;
using HospitalAPI.Patient;
using HospitalAPI.Doctor;
using HospitalAPI.Study;
using HospitalAPI.Middleware;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories with Dependency Injection (Scoped lifetime)
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IStudyRepository, StudyRepository>();

// Register Services with Dependency Injection (Scoped lifetime)
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IStudyService, StudyService>();

// Register FluentValidation validators
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Initialize database with seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Initialize(db);
}

// Configure the HTTP request pipeline
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// Fallback to index.html for SPA routing
app.MapFallbackToFile("index.html");

app.Run();
