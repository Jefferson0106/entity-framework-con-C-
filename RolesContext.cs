using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using projectoefxs.Models;

namespace projectoefxs;

public class RolesContext : DbContext
{
    public DbSet<Usuario> Usuarios {get;set;}
    public DbSet<Rol> Rols {get;set;}

    public RolesContext(DbContextOptions<RolesContext> options) :base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Usuario> usuariosInit = new List<Usuario>();
        usuariosInit.Add(new Usuario() { UsuarioId = Guid.Parse("b16a5720-10f6-4b9c-93df-298b4d5431ed"), Correo = "jefferson123@gmail.com", Contraseña = "Dios123**@" });
         usuariosInit.Add(new Usuario() { UsuarioId = Guid.Parse("b16a5720-10f6-4b9c-93df-298b4d543112"), Correo = "jonatan@gmail.com", Contraseña = "Dios123**@" });
        modelBuilder.Entity<Usuario>(usuario =>
        {
            usuario.ToTable("Usuario");
            usuario.HasKey(p=> p.UsuarioId);

            usuario.Property(p=> p.Correo).IsRequired().HasMaxLength(200);

            usuario.Property(p=> p.Contraseña).IsRequired().HasMaxLength(30);

            usuario.HasData(usuariosInit);
        });

        List<Rol> rolsInt = new List<Rol>();

        rolsInt.Add(new Rol() { RolId = Guid.Parse("b16a5720-10f6-4b9c-93df-298b4d543110"), UsuarioId =  Guid.Parse("b16a5720-10f6-4b9c-93df-298b4d5431ed"), Nombre = "Jefferson", Apellido = "Martinez", Cargo = "Ingeniero", Telefono = "04167170715", PrioridadRol = Prioridad.Vendedor, FechaCreacion = DateTime.Now });
        rolsInt.Add(new Rol() { RolId = Guid.Parse("b16a5720-10f6-4b9c-93df-298b4d543120"), UsuarioId =  Guid.Parse("b16a5720-10f6-4b9c-93df-298b4d543112"), Nombre = "Jonahtan", Apellido = "Falcon", Cargo = "Ingeniero junior pres", Telefono = "04127171715", PrioridadRol = Prioridad.Administrador, FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Rol>(rol=>
        {
            rol.ToTable("Rol");
            rol.HasKey(p=> p.RolId);

            rol.HasOne(p=> p.Usuario).WithMany(p=> p.Rols).HasForeignKey(p=> p.UsuarioId);

            rol.Property(p=> p.Nombre).IsRequired();

            rol.Property(p=> p.Apellido).IsRequired();

            rol.Property(p=> p.Cargo).IsRequired();

            rol.Property(p=> p.Telefono);

            rol.Property(p=> p.PrioridadRol);

            rol.Property(p=> p.FechaCreacion);

            rol.HasData(rolsInt);


        });
    }
}