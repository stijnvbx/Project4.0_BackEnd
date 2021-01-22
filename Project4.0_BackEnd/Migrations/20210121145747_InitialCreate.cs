using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Project4._0_BackEnd.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Box",
                columns: table => new
                {
                    BoxID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.BoxID);
                });

            migrationBuilder.CreateTable(
                name: "Sensortype",
                columns: table => new
                {
                    SensorTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Unit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensortype", x => x.SensorTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Usertype",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserTypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usertype", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Monitoring",
                columns: table => new
                {
                    MonitoringID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatteryPercentage = table.Column<double>(type: "double precision", nullable: false),
                    BatteryStatus = table.Column<bool>(type: "boolean", nullable: false),
                    SDCapacity = table.Column<double>(type: "double precision", nullable: false),
                    BoxID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoring", x => x.MonitoringID);
                    table.ForeignKey(
                        name: "FK_Monitoring_Box_BoxID",
                        column: x => x.BoxID,
                        principalTable: "Box",
                        principalColumn: "BoxID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    SensorID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SensorTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.SensorID);
                    table.ForeignKey(
                        name: "FK_Sensor_Sensortype_SensorTypeID",
                        column: x => x.SensorTypeID,
                        principalTable: "Sensortype",
                        principalColumn: "SensorTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    UserTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Usertype_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "Usertype",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorBox",
                columns: table => new
                {
                    BoxID = table.Column<int>(type: "integer", nullable: false),
                    SensorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorBox", x => new { x.BoxID, x.SensorID });
                    table.ForeignKey(
                        name: "FK_SensorBox_Box_BoxID",
                        column: x => x.BoxID,
                        principalTable: "Box",
                        principalColumn: "BoxID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorBox_Sensor_SensorID",
                        column: x => x.SensorID,
                        principalTable: "Sensor",
                        principalColumn: "SensorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoxUser",
                columns: table => new
                {
                    BoxUserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BoxID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxUser", x => x.BoxUserID);
                    table.ForeignKey(
                        name: "FK_BoxUser_Box_BoxID",
                        column: x => x.BoxID,
                        principalTable: "Box",
                        principalColumn: "BoxID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxUser_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SensorID = table.Column<int>(type: "integer", nullable: false),
                    BoxID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.MeasurementID);
                    table.ForeignKey(
                        name: "FK_Measurement_SensorBox_BoxID_SensorID",
                        columns: x => new { x.BoxID, x.SensorID },
                        principalTable: "SensorBox",
                        principalColumns: new[] { "BoxID", "SensorID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BoxUserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Location_BoxUser_BoxUserID",
                        column: x => x.BoxUserID,
                        principalTable: "BoxUser",
                        principalColumn: "BoxUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoxUser_BoxID",
                table: "BoxUser",
                column: "BoxID");

            migrationBuilder.CreateIndex(
                name: "IX_BoxUser_UserID",
                table: "BoxUser",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_BoxUserID",
                table: "Location",
                column: "BoxUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_BoxID_SensorID",
                table: "Measurement",
                columns: new[] { "BoxID", "SensorID" });

            migrationBuilder.CreateIndex(
                name: "IX_Monitoring_BoxID",
                table: "Monitoring",
                column: "BoxID");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_SensorTypeID",
                table: "Sensor",
                column: "SensorTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SensorBox_SensorID",
                table: "SensorBox",
                column: "SensorID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                table: "User",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "Monitoring");

            migrationBuilder.DropTable(
                name: "BoxUser");

            migrationBuilder.DropTable(
                name: "SensorBox");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Box");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Usertype");

            migrationBuilder.DropTable(
                name: "Sensortype");
        }
    }
}
