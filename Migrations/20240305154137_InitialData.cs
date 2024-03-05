using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectoefxs.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Contraseña", "Correo" },
                values: new object[] { new Guid("b16a5720-10f6-4b9c-93df-298b4d543112"), "Dios123**@", "jonatan@gmail.com" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Contraseña", "Correo" },
                values: new object[] { new Guid("b16a5720-10f6-4b9c-93df-298b4d5431ed"), "Dios123**@", "jefferson123@gmail.com" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "RolId", "Apellido", "Cargo", "FechaCreacion", "Nombre", "PrioridadRol", "Telefono", "UsuarioId" },
                values: new object[] { new Guid("b16a5720-10f6-4b9c-93df-298b4d543110"), "Martinez", "Ingeniero", new DateTime(2024, 3, 5, 11, 41, 37, 223, DateTimeKind.Local).AddTicks(5780), "Jefferson", 1, "04167170715", new Guid("b16a5720-10f6-4b9c-93df-298b4d5431ed") });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "RolId", "Apellido", "Cargo", "FechaCreacion", "Nombre", "PrioridadRol", "Telefono", "UsuarioId" },
                values: new object[] { new Guid("b16a5720-10f6-4b9c-93df-298b4d543120"), "Falcon", "Ingeniero junior pres", new DateTime(2024, 3, 5, 11, 41, 37, 223, DateTimeKind.Local).AddTicks(5805), "Jonahtan", 0, "04127171715", new Guid("b16a5720-10f6-4b9c-93df-298b4d543112") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "RolId",
                keyValue: new Guid("b16a5720-10f6-4b9c-93df-298b4d543110"));

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "RolId",
                keyValue: new Guid("b16a5720-10f6-4b9c-93df-298b4d543120"));

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "UsuarioId",
                keyValue: new Guid("b16a5720-10f6-4b9c-93df-298b4d543112"));

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "UsuarioId",
                keyValue: new Guid("b16a5720-10f6-4b9c-93df-298b4d5431ed"));
        }
    }
}
