using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegisterApplications.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CourierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Couriers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Couriers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "Cargo", "Comment", "CourierId", "Name", "Recipient", "Sender", "Status" },
                values: new object[] { 1, "Коробка", null, null, "Заявка 1", "Петров Петр Петрович", "Иванов Иван Иванович", 0 });

            migrationBuilder.InsertData(
                table: "Couriers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Валерий" },
                    { 2, "Антон" },
                    { 3, "Олег" }
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "Cargo", "Comment", "CourierId", "Name", "Recipient", "Sender", "Status" },
                values: new object[,]
                {
                    { 2, "Печь для бани", "Отмена из-за погодных условий", 1, "Заявка 2", "Мягков Виталий Олегович", "Иванов Владислав Дмитриевич", 3 },
                    { 3, "Телефон", null, 2, "Заявка 3", "Пупкин Сергей Викторович", "Сидоров Олег Дмитриевич", 2 },
                    { 4, "Трубы", null, 3, "Заявка 4", "Васильев Роман Валерьевич", "Смирнов Юрий Николаевич", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_CourierId",
                table: "Bids",
                column: "CourierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Couriers");
        }
    }
}
