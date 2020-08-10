using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FELFEL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    BatchStateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batch_BatchState_BatchStateId",
                        column: x => x.BatchStateId,
                        principalTable: "BatchState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    OrderStateId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderState_OrderStateId",
                        column: x => x.OrderStateId,
                        principalTable: "OrderState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Batch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryHistory_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryHistory_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryHistory_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BatchState",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Fresh" },
                    { 2, "ExpiringToday" },
                    { 3, "Expired" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Customer1" },
                    { 2, "Customer2" },
                    { 3, "Customer3" },
                    { 4, "Customer4" },
                    { 5, "Customer5" }
                });

            migrationBuilder.InsertData(
                table: "OrderState",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 3, "Received" },
                    { 1, "Pending" },
                    { 2, "On Going" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Onions" },
                    { 13, "Tuna" },
                    { 12, "Sardines" },
                    { 11, "Shrimp" },
                    { 10, "Tomatoes" },
                    { 8, "Asparagus" },
                    { 4, "Broccoli" },
                    { 6, "Avocados" },
                    { 5, "Apples" },
                    { 3, "Chicken Meat" },
                    { 2, "Bread" },
                    { 1, "Pasta" },
                    { 7, "Eggs" }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Supplier4" },
                    { 1, "Supplier1" },
                    { 2, "Supplier2" },
                    { 3, "Supplier3" },
                    { 5, "Supplier5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batch_BatchStateId",
                table: "Batch",
                column: "BatchStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Batch_ExpirationDate",
                table: "Batch",
                column: "ExpirationDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_BatchId",
                table: "Inventory",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_CustomerId",
                table: "InventoryHistory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_InventoryId",
                table: "InventoryHistory",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_SupplierId",
                table: "InventoryHistory",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStateId",
                table: "Order",
                column: "OrderStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SupplierId",
                table: "Order",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryHistory");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "OrderState");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "BatchState");
        }
    }
}
