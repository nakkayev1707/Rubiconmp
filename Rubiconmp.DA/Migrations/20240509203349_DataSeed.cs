using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rubiconmp.DA.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DECLARE @Id INT = 1;
                DECLARE @X FLOAT;
                DECLARE @Y FLOAT;
                DECLARE @Width FLOAT;
                DECLARE @Height FLOAT;

                WHILE @Id <= 500000
                BEGIN
                    SET @X = ROUND(RAND() * 10, 0);
                    SET @Y = ROUND(RAND() * 10, 0);
                    SET @Width = ROUND(RAND() * 50 + 1, 0);
                    SET @Height = ROUND(RAND() * 50 + 1, 0);

                    INSERT INTO Rectangles (X, Y, Width, Height)
                    VALUES (@X, @Y, @Width, @Height);

                    SET @Id = @Id + 1;
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("truncate table Rectangles;");
        }
    }
}
