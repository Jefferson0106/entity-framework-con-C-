using System.Text.Json.Serialization;

namespace projectoefxs.Models;

public class Usuario 
{
    public Guid UsuarioId {get;set;}

    public string Correo {get;set;}

    public string Contraseña {get;set;}

[JsonIgnore]
    public virtual ICollection<Rol> Rols {get;set;}
}