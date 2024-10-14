using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Infrago.API.Migrations
{
    /// <inheritdoc />
    public partial class Relationstoseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Stockist",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ToolAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ProjectDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockistsId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "MachineryAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToolAssignments_ProjectId",
                table: "ToolAssignments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectId",
                table: "Projects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DepartmentId",
                table: "Orders",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StockistsId",
                table: "Orders",
                column: "StockistsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MaterialId",
                table: "OrderDetails",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineryAssignments_ProjectId",
                table: "MachineryAssignments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_MaterialId",
                table: "Assignments",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ProjectId",
                table: "Assignments",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Materials_MaterialId",
                table: "Assignments",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Projects_ProjectId",
                table: "Assignments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineryAssignments_Projects_ProjectId",
                table: "MachineryAssignments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Materials_MaterialId",
                table: "OrderDetails",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Departments_DepartmentId",
                table: "Orders",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stockists_StockistsId",
                table: "Orders",
                column: "StockistsId",
                principalTable: "Stockists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDetails_Projects_ProjectId",
                table: "ProjectDetails",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Clients_ClientId",
                table: "Projects",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Projects_ProjectId",
                table: "Projects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToolAssignments_Projects_ProjectId",
                table: "ToolAssignments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Materials_MaterialId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Projects_ProjectId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineryAssignments_Projects_ProjectId",
                table: "MachineryAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Materials_MaterialId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Departments_DepartmentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stockists_StockistsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDetails_Projects_ProjectId",
                table: "ProjectDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Clients_ClientId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Projects_ProjectId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ToolAssignments_Projects_ProjectId",
                table: "ToolAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ToolAssignments_ProjectId",
                table: "ToolAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DepartmentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StockistsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_MaterialId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_MachineryAssignments_ProjectId",
                table: "MachineryAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_MaterialId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_ProjectId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ToolAssignments");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectDetails");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StockistsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "MachineryAssignments");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Assignments");

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Stockist",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "OrderDetails",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Order",
                table: "OrderDetails",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Assignments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectName",
                table: "Projects",
                column: "ProjectName",
                unique: true);
        }
    }
}
