using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VideoBench.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "video");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "category");

            migrationBuilder.AddColumn<int>(
                name: "Bitrate",
                table: "video",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "video",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "video",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SourceId",
                table: "video",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "video",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "category",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_video",
                table: "video",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "quality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "video_test",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QualityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_test_quality_QualityId",
                        column: x => x.QualityId,
                        principalTable: "quality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryVideoTest",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    VideoTestsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryVideoTest", x => new { x.CategoriesId, x.VideoTestsId });
                    table.ForeignKey(
                        name: "FK_CategoryVideoTest_category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryVideoTest_video_test_VideoTestsId",
                        column: x => x.VideoTestsId,
                        principalTable: "video_test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "survey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeviceType = table.Column<int>(type: "integer", nullable: false),
                    VideoTestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_survey_video_test_VideoTestId",
                        column: x => x.VideoTestId,
                        principalTable: "video_test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorySurvey",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    SurveysId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySurvey", x => new { x.CategoriesId, x.SurveysId });
                    table.ForeignKey(
                        name: "FK_CategorySurvey_category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySurvey_survey_SurveysId",
                        column: x => x.SurveysId,
                        principalTable: "survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_video_SurveyId",
                table: "video",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySurvey_SurveysId",
                table: "CategorySurvey",
                column: "SurveysId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVideoTest_VideoTestsId",
                table: "CategoryVideoTest",
                column: "VideoTestsId");

            migrationBuilder.CreateIndex(
                name: "IX_survey_VideoTestId",
                table: "survey",
                column: "VideoTestId");

            migrationBuilder.CreateIndex(
                name: "IX_video_test_QualityId",
                table: "video_test",
                column: "QualityId");

            migrationBuilder.AddForeignKey(
                name: "FK_video_survey_SurveyId",
                table: "video",
                column: "SurveyId",
                principalTable: "survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_survey_SurveyId",
                table: "video");

            migrationBuilder.DropTable(
                name: "CategorySurvey");

            migrationBuilder.DropTable(
                name: "CategoryVideoTest");

            migrationBuilder.DropTable(
                name: "survey");

            migrationBuilder.DropTable(
                name: "video_test");

            migrationBuilder.DropTable(
                name: "quality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_video",
                table: "video");

            migrationBuilder.DropIndex(
                name: "IX_video_SurveyId",
                table: "video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropColumn(
                name: "Bitrate",
                table: "video");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "video");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "video");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "video");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "video");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "category");

            migrationBuilder.RenameTable(
                name: "video",
                newName: "Videos");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });
        }
    }
}
