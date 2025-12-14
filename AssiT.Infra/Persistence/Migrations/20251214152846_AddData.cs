using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssiT.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                    "Id", "Name", "Email", "Password", "Perfil", "IsDeleted", "CreatedAt"
                },
                values: new object[,]
                {
                {//Senha : String@123456
                    1, "Admin User", "admin@assit.com", "a1bd86eef60a15e4ddffb532d61164e02bf706b2bb791d6c5965a03bed6c2fc5", 1, false, DateTime.UtcNow
                },
                {
                    2, "Manager User", "manager@assit.com", "a1bd86eef60a15e4ddffb532d61164e02bf706b2bb791d6c5965a03bed6c2fc5", 2,  false, DateTime.UtcNow
                },
                {
                    3, "Regular User", "user@assit.com", "a1bd86eef60a15e4ddffb532d61164e02bf706b2bb791d6c5965a03bed6c2fc5",2,false, DateTime.UtcNow
                }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[]
                {
                    "Id", "Name", "IsDeleted", "CreatedAt"
                },
                values: new object[,]
                {
                    { 1, "Hardware", false, DateTime.UtcNow },
                    { 2, "Software", false, DateTime.UtcNow },
                    { 3, "Rede", false, DateTime.UtcNow }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[]
                {   
                    "Id", "Name","SerialNumber", "AcquisitionDate", "AcquisitionValue","CategoryId", "AssetStatus", "IsDeleted", "CreatedAt"
                },
                values: new object[,]
                {
                    { 1, "Dell Latitude 5420", "HW-001", new DateTime(2023, 01, 10), 4500m, 1, 1, false, DateTime.UtcNow },
                    { 2, "Monitor LG 24''", "HW-002", new DateTime(2023, 02, 05), 800m, 1, 1, false, DateTime.UtcNow },
                    { 3, "Teclado Logitech K380", "HW-003", new DateTime(2023, 03, 12), 150m, 1, 1, false, DateTime.UtcNow },
        
                    { 4, "Microsoft Office 365", "SW-004", new DateTime(2023, 01, 01), 350m, 2, 1, false, DateTime.UtcNow },
                    { 5, "Adobe Creative Cloud", "SW-005", new DateTime(2023, 04, 01), 200m, 2, 1, false, DateTime.UtcNow },
                    { 6, "Visual Studio Rider", "SW-006", new DateTime(2023, 05, 20), 500m, 2, 1, false, DateTime.UtcNow },
        
                    { 7, "Switch Cisco 24 Portas", "NW-007", new DateTime(2022, 11, 20), 3200m, 3, 1, false, DateTime.UtcNow },
                    { 8, "Roteador TP-Link AC1750", "NW-008", new DateTime(2023, 06, 15), 450m, 3, 1, false, DateTime.UtcNow },
                    { 9, "Access Point Ubiquiti", "NW-009", new DateTime(2023, 07, 10), 900m, 3, 1, false, DateTime.UtcNow }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Assets", "Id", new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            migrationBuilder.DeleteData("Categories", "Id", new object[] { 1, 2, 3 });
            migrationBuilder.DeleteData("Users", "Id", new object[] { 1, 2, 3 });
        }
    }
}
