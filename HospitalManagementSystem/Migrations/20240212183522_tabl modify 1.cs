using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    public partial class tablmodify1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Citizenship",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalIdentityNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalIdentityType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isNIDSearchActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastNIDSearch",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nIDSearchActiveTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nIDSearchCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nidFailCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userFrom",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "nidFailCountStart",
                table: "AspNetUsers",
                newName: "otpVerifiedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "otpVerifiedDate",
                table: "AspNetUsers",
                newName: "nidFailCountStart");

            migrationBuilder.AddColumn<int>(
                name: "AddressType",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Citizenship",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalIdentityNo",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalIdentityType",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isNIDSearchActive",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastNIDSearch",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "nIDSearchActiveTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nIDSearchCount",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nidFailCount",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userFrom",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
