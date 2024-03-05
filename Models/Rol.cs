namespace projectoefxs.Models;

public class Rol
{
    public Guid RolId {get;set;}
    public Guid UsuarioId {get;set;}

    public string Nombre {get;set;}

    public string Apellido {get;set;}

    public string   Cargo {get;set;}

    public string Telefono {get;set;}

    public Prioridad PrioridadRol {get;set;}

    public DateTime FechaCreacion {get;set;}

    public virtual Usuario Usuario {get;set;}
}

public enum Prioridad 
{
    Administrador,
    Vendedor
}