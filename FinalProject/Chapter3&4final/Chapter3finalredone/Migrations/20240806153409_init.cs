using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chapter3finalredone.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkoutLogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    WorkoutLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.WorkoutLogId);
                    table.ForeignKey(
                        name: "FK_Workouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workoutLogExercises",
                columns: table => new
                {
                    WorkoutLogId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workoutLogExercises", x => new { x.WorkoutLogId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_workoutLogExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workoutLogExercises_Workouts_WorkoutLogId",
                        column: x => x.WorkoutLogId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "Description", "ExerciseName" },
                values: new object[,]
                {
                    { 1, "A squat is a strength exercise that involves lowering the hips from a standing position and then standing back up.", "Squats" },
                    { 2, "The bench press is a compound exercise that targets the muscles of the upper body.", "Bench Press" },
                    { 3, "The bent-over row is an exercise you can do with dumbbells to work the muscles in the back of the shoulder", "Row" },
                    { 4, "A barbell curl is a variation of the biceps curl that uses a weighted barbell. ", "Barbell Curl" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Reason", "UserName", "WorkoutLogId" },
                values: new object[,]
                {
                    { 1, "killerclutch@gmail.com", "Lose weight.", "Joshua555", null },
                    { 2, "Random616@gmail.com", "Gain weight.", "Random616", null },
                    { 3, "CoolBeans83@gmail.com", "I want to jump higher.", "CoolBeans83", null },
                    { 4, "Fitnessguy454@gmail.com", "I want to fill out shirts.", "Fitnessguy454", null }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "WorkoutLogId", "Date", "Notes", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2021, 10, 1), "I struggled with leg day.", 1 },
                    { 2, new DateOnly(2021, 10, 2), "I did good on squats.", 2 },
                    { 3, new DateOnly(2021, 10, 1), "My form on front rows needs improvement.", 2 },
                    { 4, new DateOnly(2021, 10, 2), "I felt really motivated today.", 3 }
                });

            migrationBuilder.InsertData(
                table: "workoutLogExercises",
                columns: new[] { "ExerciseId", "WorkoutLogId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 4, 2 },
                    { 2, 3 },
                    { 4, 3 },
                    { 1, 4 },
                    { 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkoutLogId",
                table: "Users",
                column: "WorkoutLogId");

            migrationBuilder.CreateIndex(
                name: "IX_workoutLogExercises_ExerciseId",
                table: "workoutLogExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Workouts_WorkoutLogId",
                table: "Users",
                column: "WorkoutLogId",
                principalTable: "Workouts",
                principalColumn: "WorkoutLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Workouts_WorkoutLogId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "workoutLogExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
