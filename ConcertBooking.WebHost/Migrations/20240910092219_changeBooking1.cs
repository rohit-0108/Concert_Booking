using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertBooking.WebHost.Migrations
{
    /// <inheritdoc />
    public partial class changeBooking1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Concerts_ConcertId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ConcertId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConcertId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ConcertId",
                table: "Bookings",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Concerts_ConcertId",
                table: "Bookings",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Concerts_ConcertId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ConcertId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "ConcertId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConcertId",
                table: "Tickets",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Concerts_ConcertId",
                table: "Tickets",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
