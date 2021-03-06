// <auto-generated />
namespace phoneBookAPI.Migrations

open System
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Infrastructure
open Microsoft.EntityFrameworkCore.Metadata
open Microsoft.EntityFrameworkCore.Migrations
open Microsoft.EntityFrameworkCore.Storage.ValueConversion
open Npgsql.EntityFrameworkCore.PostgreSQL.Metadata
open PhoneBook.Data

[<DbContext(typeof<Context.DatabaseContext>)>]
[<Migration("20210827165139_Init")>]
type Init() =
    inherit Migration()

    override this.Up(migrationBuilder:MigrationBuilder) =
        migrationBuilder.CreateTable(
            name = "Contacts"
            ,columns = (fun table -> 
            {|
                Id =
                    table.Column<int>(
                        nullable = false
                        ,``type`` = "integer"
                    ).Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                Name =
                    table.Column<string>(
                        nullable = false
                        ,``type`` = "text"
                    )
            |})
            ,constraints =
                (fun table -> 
                    table.PrimaryKey("PK_Contacts", (fun x -> (x.Id) :> obj)) |> ignore
                ) 
        ) |> ignore

        migrationBuilder.CreateTable(
            name = "PhoneNumbers"
            ,columns = (fun table -> 
            {|
                Id =
                    table.Column<int>(
                        nullable = false
                        ,``type`` = "integer"
                    ).Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                Type =
                    table.Column<string>(
                        nullable = true
                        ,``type`` = "text"
                    )
                Number =
                    table.Column<string>(
                        nullable = true
                        ,``type`` = "text"
                    )
                ContactId =
                    table.Column<int>(
                        nullable = true
                        ,``type`` = "integer"
                    )
            |})
            ,constraints =
                (fun table -> 
                    table.PrimaryKey("PK_PhoneNumbers", (fun x -> (x.Id) :> obj)) |> ignore
                    table.ForeignKey(
                        name = "FK_PhoneNumbers_Contacts_ContactId",
                        column = (fun x -> (x.ContactId) :> obj)
                        ,principalTable = "Contacts"
                        ,principalColumn = "Id"
                        ,onDelete = ReferentialAction.Restrict
                        ) |> ignore

                ) 
        ) |> ignore

        migrationBuilder.CreateIndex(
            name = "IX_PhoneNumbers_ContactId"
            ,table = "PhoneNumbers"
            ,column = "ContactId"
            ) |> ignore


    override this.Down(migrationBuilder:MigrationBuilder) =
        migrationBuilder.DropTable(
            name = "PhoneNumbers"
            ) |> ignore

        migrationBuilder.DropTable(
            name = "Contacts"
            ) |> ignore


    override this.BuildTargetModel(modelBuilder: ModelBuilder) =
        modelBuilder

            .UseIdentityByDefaultColumns().HasAnnotation("Relational:MaxIdentifierLength", 63)
            .HasAnnotation("ProductVersion", "5.0.0")
            |> ignore

        modelBuilder.Entity("PhoneBook.Model.Contact", (fun b ->

            b.Property<int>("Id")
                .IsRequired(true)
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .UseIdentityByDefaultColumn() |> ignore
            b.Property<string>("Name")
                .IsRequired(true)
                .HasColumnType("text") |> ignore

            b.HasKey("Id") |> ignore

            b.ToTable("Contacts") |> ignore

        )) |> ignore

        modelBuilder.Entity("PhoneBook.Model.PhoneNumber", (fun b ->

            b.Property<int>("Id")
                .IsRequired(true)
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .UseIdentityByDefaultColumn() |> ignore
            b.Property<Nullable<int>>("ContactId")
                .IsRequired(true)
                .HasColumnType("integer") |> ignore
            b.Property<string>("Number")
                .IsRequired(false)
                .HasColumnType("text") |> ignore
            b.Property<string>("Type")
                .IsRequired(false)
                .HasColumnType("text") |> ignore

            b.HasKey("Id") |> ignore


            b.HasIndex("ContactId") |> ignore

            b.ToTable("PhoneNumbers") |> ignore

        )) |> ignore

        modelBuilder.Entity("PhoneBook.Model.PhoneNumber", (fun b ->
            b.HasOne("PhoneBook.Model.Contact",null)
                .WithMany("PhoneNumbers")
                .HasForeignKey("ContactId") |> ignore
        )) |> ignore

