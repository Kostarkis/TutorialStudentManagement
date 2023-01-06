using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TutorialStudentManagement.Models;
using TutorialStudentManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<StudentStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(StudentStoreDatabaseSettings)));

builder.Services.AddSingleton<IStudentStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<StudentStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton <IMongoClient>(sp => 
    new MongoClient(sp.GetRequiredService<IStudentStoreDatabaseSettings>().ConnectionString));

builder.Services.AddSingleton<IStudentService, StudentService>();

// Add services to the container.

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
