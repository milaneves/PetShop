using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAnimal = table.Column<string>(type: "varchar(150)", nullable: false),
                    MotivoInternacao = table.Column<string>(type: "varchar(200)", nullable: false),
                    EstadoSaude = table.Column<string>(type: "varchar(50)", nullable: false),
                    NomeTutor = table.Column<string>(type: "varchar(100)", nullable: false),
                    EnderecoTutor = table.Column<string>(type: "varchar(150)", nullable: false),
                    TelefoneTutor = table.Column<string>(type: "varchar(20)", nullable: false),
                    AlojamentoId = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Alojamento_AlojamentoId",
                        column: x => x.AlojamentoId,
                        principalTable: "Alojamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alojamento",
                columns: new[] { "Id", "Status" },
                values: new object[] { 1, "Livre" });

            migrationBuilder.InsertData(
                table: "Alojamento",
                columns: new[] { "Id", "Status" },
                values: new object[] { 2, "Livre" });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AlojamentoId",
                table: "Animal",
                column: "AlojamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Alojamento");
        }
    }
}
