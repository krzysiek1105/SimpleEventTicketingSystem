using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleEventTicketingSystem.Infrastructure.Migrations
{
    public partial class EventTicketCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Events_EventId",
                table: "Ticket");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Events_EventId",
                table: "Ticket",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Events_EventId",
                table: "Ticket");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Events_EventId",
                table: "Ticket",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
