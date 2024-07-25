using homework01_minimalApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TasksDbContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapGet("/GetAllTasks", async (TasksDbContext db) =>
{
    return await db.ToDoTasks.ToListAsync();
})
 .WithName("GetAllTasks").WithOpenApi();

app.MapPost("/AddTask", async (TasksDbContext db, [FromBody]ToDoTask task) =>
{
    db.ToDoTasks.Add(task);
    await db.SaveChangesAsync();
    return Results.Created($"/GetAllTasks", task);
})
.WithName("AddTask")
.WithOpenApi();

app.MapGet("/GetTask/{id}", async (TasksDbContext db, int id) =>
{
    return await db.ToDoTasks.FindAsync(id);
})
 .WithName("GetTaskById").WithOpenApi();

app.MapPatch("/EditTask/{id}", async (TasksDbContext db, int id,DateTime due, string name = default,  bool isDone = default) =>
{
    var task = await db.ToDoTasks.FindAsync(id);
    task.Due = due;
    if (!String.IsNullOrEmpty(name)) task.Name = name;
    if (isDone != default) task.IsDone = isDone;
    await db.SaveChangesAsync();
    return Results.Accepted($"/GetAllTasks");
})
.WithName("EditTask")
.WithOpenApi();



app.Run();

