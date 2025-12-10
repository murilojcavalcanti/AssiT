using AssiT.Core.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Net.Mail;

#nullable disable

namespace AssiT.Infra.Persistence.Migrations
{
    public partial class AdicionandoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserir dois usuários
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] {"Name","Email","Password", "IsDeleted", "createdAt"
                },
                values: new object[,]
                {
                    {"João Silva", "joao.silva@email.com", "senha123",false,DateTime.Now },
                    {"Maria Souza", "maria.souza@email.com", "senha456",false,DateTime.Now }
                }
            );

            // Inserir três contatos para cada usuário
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] {"UserId","Alias","PhoneNumber","EmailAdress","IsDeleted","createdAt"


                },
                values: new object[,]
                {
                    { 1,"Carlos Pereira", "11999990001", "carlos@email.com", false, DateTime.Now },
                    { 1,"Ana Lima", "11999990002", "ana@email.com", false, DateTime.Now },
                    { 1,"Fernanda Costa", "11999990003", "fernanda@email.com", false, DateTime.Now },
                    { 2,"Pedro Santos", "21999990001", "pedro@email.com", false, DateTime.Now },
                    { 2,"Juliana Alves", "21999990002", "juliana@email.com", false, DateTime.Now },
                    { 2,"Ricardo Dias", "21999990003", "ricardo@email.com", false, DateTime.Now }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover os contatos inseridos
            migrationBuilder.DeleteData(
                table: "Contatos",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6 }
            );

            // Remover os usuários inseridos
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2 }
            );
        }
    }
}
