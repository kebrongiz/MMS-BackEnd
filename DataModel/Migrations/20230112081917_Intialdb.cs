using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModels.Migrations
{
    /// <inheritdoc />
    public partial class Intialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fpNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeId);
                });

            migrationBuilder.CreateTable(
                name: "StoreHeaders",
                columns: table => new
                {
                    storeHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delivererId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delivererTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delivererFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delivererMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delivererLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverFp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreHeaders", x => x.storeHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialItems",
                columns: table => new
                {
                    materilItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unitPrice = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: true),
                    storeHeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialItems", x => x.materilItemId);
                    table.ForeignKey(
                        name: "FK_MaterialItems_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "employeeId");
                    table.ForeignKey(
                        name: "FK_MaterialItems_StoreHeaders_storeHeaderId",
                        column: x => x.storeHeaderId,
                        principalTable: "StoreHeaders",
                        principalColumn: "storeHeaderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialItems_employeeId",
                table: "MaterialItems",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialItems_storeHeaderId",
                table: "MaterialItems",
                column: "storeHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialItems");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "StoreHeaders");
        }
    }
}
