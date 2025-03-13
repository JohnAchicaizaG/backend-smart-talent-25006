using Microsoft.EntityFrameworkCore;
using TaskManagerBackendSmartTalent.Data;
using TaskManagerBackendSmartTalent.src.Repositories;
using TaskManagerBackendSmartTalent.src.Services; 

var builder = WebApplication.CreateBuilder(args);

// la conexión a la base de datos
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registrar dependencias
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>(); 

// Otras configuraciones
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseAuthorization();
app.MapControllers();

app.Run();