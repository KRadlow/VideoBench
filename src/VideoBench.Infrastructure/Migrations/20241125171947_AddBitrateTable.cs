using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoBench.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBitrateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVideoTest_Tests_TestsId",
                table: "CategoryVideoTest");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Tests_TestId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Qualities_QualityId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "VideoTests");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_QualityId",
                table: "VideoTests",
                newName: "IX_VideoTests_QualityId");

            migrationBuilder.AddColumn<int>(
                name: "SamplesNumber",
                table: "VideoTests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoTests",
                table: "VideoTests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BitrateValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitrateValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BitrateVideoTest",
                columns: table => new
                {
                    BitrateValuesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitrateVideoTest", x => new { x.BitrateValuesId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_BitrateVideoTest_BitrateValues_BitrateValuesId",
                        column: x => x.BitrateValuesId,
                        principalTable: "BitrateValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BitrateVideoTest_VideoTests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "VideoTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BitrateVideoTest_TestsId",
                table: "BitrateVideoTest",
                column: "TestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVideoTest_VideoTests_TestsId",
                table: "CategoryVideoTest",
                column: "TestsId",
                principalTable: "VideoTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_VideoTests_TestId",
                table: "Surveys",
                column: "TestId",
                principalTable: "VideoTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTests_Qualities_QualityId",
                table: "VideoTests",
                column: "QualityId",
                principalTable: "Qualities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVideoTest_VideoTests_TestsId",
                table: "CategoryVideoTest");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_VideoTests_TestId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoTests_Qualities_QualityId",
                table: "VideoTests");

            migrationBuilder.DropTable(
                name: "BitrateVideoTest");

            migrationBuilder.DropTable(
                name: "BitrateValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoTests",
                table: "VideoTests");

            migrationBuilder.DropColumn(
                name: "SamplesNumber",
                table: "VideoTests");

            migrationBuilder.RenameTable(
                name: "VideoTests",
                newName: "Tests");

            migrationBuilder.RenameIndex(
                name: "IX_VideoTests_QualityId",
                table: "Tests",
                newName: "IX_Tests_QualityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVideoTest_Tests_TestsId",
                table: "CategoryVideoTest",
                column: "TestsId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Tests_TestId",
                table: "Surveys",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Qualities_QualityId",
                table: "Tests",
                column: "QualityId",
                principalTable: "Qualities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
