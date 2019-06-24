using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microsoft.eShopWeb.Infrastructure.Migrations
{
    public partial class AppUserDbUpgrade1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AchievedLevel",
                table: "UserProfile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "AchievedPoints",
                table: "UserProfile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Continent",
                table: "UserProfile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "UserProfile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ExperienceLevel",
                table: "UserProfile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserProfile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LatestLogin",
                table: "UserProfile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserStatus",
                table: "UserProfile",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AchievedLevel",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "AchievedPoints",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Continent",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "ExperienceLevel",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "LatestLogin",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "UserProfile");
        }
    }
}
