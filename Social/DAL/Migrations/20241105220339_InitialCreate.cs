using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uesrProfiles",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FristName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uesrProfiles", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatedPost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_uesrProfiles_UserID",
                        column: x => x.UserID,
                        principalTable: "uesrProfiles",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "uesrProfiles",
                columns: new[] { "UserID", "DateOfBirth", "Email", "FristName", "LastName", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmedhasseb310@gmail.com", "Ahmed", "Mohamed", 0 },
                    { 2, new DateTime(1999, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MohamedAlaa12@gmail.com", "Mohamed", "Alaa", 0 },
                    { 3, new DateTime(1999, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "AliMohamed@gmail.com", "Ali", "Ahmed", 0 },
                    { 4, new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "YaserAli10@gmail.com", "Yasser", "Ali", 0 },
                    { 5, new DateTime(2000, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ManarMohamed311@gmail.com", "Manar", "Mohamed", 0 },
                    { 6, new DateTime(2001, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "saraAhmedOficial@gmail.com", "Sara", "Ahmed", 0 },
                    { 7, new DateTime(1995, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "HemaHesham40@gmail.com", "Ibrahim", "Hesham", 0 },
                    { 8, new DateTime(1992, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaMostafa55@gmail.com", "Esraa", "Mostafa", 0 },
                    { 9, new DateTime(2005, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZeyadAdel665@gmail.com", "Zeyad", "Adel", 0 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Content", "DatedPost", "State", "Title", "UserID" },
                values: new object[,]
                {
                    { 1, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(972), 0, "interduction1", 1 },
                    { 2, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(977), 0, "interduction1", 1 },
                    { 3, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(983), 0, "interductionTwo", 2 },
                    { 4, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(988), 0, "interductionTwo", 2 },
                    { 5, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(993), 0, "interductionThree", 3 },
                    { 6, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(998), 0, "interductionFor", 4 },
                    { 7, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(1003), 0, "interductionFive", 5 },
                    { 8, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(1007), 0, "interductionSix", 6 },
                    { 9, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(1012), 0, "interductionSix", 6 },
                    { 10, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(1017), 0, "interductionSeven", 7 },
                    { 11, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(1021), 0, "interductionEight", 8 },
                    { 12, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(1026), 0, "interductionNiNe", 9 },
                    { 13, "English texts for beginners to practice reading", new DateTime(2024, 11, 6, 0, 3, 39, 622, DateTimeKind.Local).AddTicks(1031), 0, "interductionNine", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "uesrProfiles");
        }
    }
}
