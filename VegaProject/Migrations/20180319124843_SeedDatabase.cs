using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VegaProject.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make3')");

            migrationBuilder.Sql("INSERT INTO Models (MakeId,Name) VALUES ((SELECT Id FROM Makes WHERE Name = 'Make1'),'Make1-Model1')");
            migrationBuilder.Sql("INSERT INTO Models (MakeId,Name) VALUES ((SELECT Id FROM Makes WHERE Name = 'Make1'),'Make1-Model2')");
            migrationBuilder.Sql("INSERT INTO Models (MakeId,Name) VALUES ((SELECT Id FROM Makes WHERE Name = 'Make1'),'Make1-Model3')");

            migrationBuilder.Sql("INSERT INTO Models (MakeId,Name) VALUES ((SELECT Id FROM Makes WHERE Name = 'Make2'),'Make2-Model1')");
            migrationBuilder.Sql("INSERT INTO Models (MakeId,Name) VALUES ((SELECT Id FROM Makes WHERE Name = 'Make2'),'Make2-Model2')");
            migrationBuilder.Sql("INSERT INTO Models (MakeId,Name) VALUES ((SELECT Id FROM Makes WHERE Name = 'Make2'),'Make2-Model3')");

            migrationBuilder.Sql("INSERT INTO Models (MakeId,Name) VALUES ((SELECT Id FROM Makes WHERE Name = 'Make3'),'Make3-Model1')");
            migrationBuilder.Sql("INSERT INTO Models (MakeId,Name) VALUES ((SELECT Id FROM Makes WHERE Name = 'Make3'),'Make3-Model2')");
            migrationBuilder.Sql("INSERT INTO Models (MakeId,Name) VALUES ((SELECT Id FROM Makes WHERE Name = 'Make3'),'Make3-Model3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Make1', 'Make2', 'Make3')");
        }
    }
}
