using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectoefxs;
using projectoefxs.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<RolesContext>(p => p.UseInMemoryDatabase("proyectoDB"));
builder.Services.AddSqlServer<RolesContext>(builder.Configuration.GetConnectionString("cnRoles"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] RolesContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/rols", async ([FromServices] RolesContext dbContext)=> 
{
    return Results.Ok(dbContext.Rols.Include(p=> p.Usuario));
});

app.MapPost("/api/rols", async ([FromServices] RolesContext dbContext, [FromBody] Rol rol)=> 
{
    rol.RolId = Guid.NewGuid();
    rol.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(rol);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/rols/{id}", async ([FromServices] RolesContext dbContext, [FromBody] Rol rol, [FromRoute] Guid id)=>
{
   var rolActual = dbContext.Rols.Find(id);

   if(rolActual!=null)
   {
    rolActual.UsuarioId = rol.UsuarioId;
    rolActual.Nombre = rol.Nombre;
    rolActual.Apellido = rol.Apellido;
    rolActual.Cargo = rol.Cargo;
    rolActual.Telefono = rol.Telefono;

    await dbContext.SaveChangesAsync();

     return Results.Ok();

   }

    return Results.NotFound();
});

app.MapDelete("/api/rols/{id}", async ([FromServices] RolesContext dbContext, [FromRoute] Guid id)=>
{
    var rolActual = dbContext.Rols.Find(id);

    if(rolActual!=null)
    {
        dbContext.Remove(rolActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
