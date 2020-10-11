using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace back2Front.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgendaCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titre = table.Column<string>(maxLength: 100, nullable: true),
                    Civlite = table.Column<string>(maxLength: 100, nullable: true),
                    Prenom = table.Column<string>(maxLength: 100, nullable: false),
                    Nom = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacturationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturationCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Structures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Structures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tauxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tauxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 100, nullable: false),
                    StructureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projets_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Secteurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 100, nullable: false),
                    email = table.Column<string>(nullable: true),
                    StructureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secteurs_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StructureContacts",
                columns: table => new
                {
                    StructureId = table.Column<int>(nullable: false),
                    ContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructureContacts", x => new { x.StructureId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_StructureContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StructureContacts_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 100, nullable: false),
                    Debut = table.Column<DateTime>(nullable: false),
                    Fin = table.Column<DateTime>(nullable: false),
                    CategorieId = table.Column<int>(nullable: true),
                    ProjetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_AgendaCategories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "AgendaCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 100, nullable: false),
                    Categorie = table.Column<int>(nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    Taux = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StructureId = table.Column<int>(nullable: true),
                    ProjetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depenses_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Depenses_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 100, nullable: false),
                    ProjetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturations_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjetContacts",
                columns: table => new
                {
                    ProjetId = table.Column<int>(nullable: false),
                    ContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetContacts", x => new { x.ProjetId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_ProjetContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetContacts_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    rue = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    complement = table.Column<string>(nullable: true),
                    SecteurId = table.Column<int>(nullable: true),
                    StructureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Secteurs_SecteurId",
                        column: x => x.SecteurId,
                        principalTable: "Secteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adresses_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telephones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: true),
                    PhoneType = table.Column<int>(nullable: false),
                    SecteurId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telephones_Secteurs_SecteurId",
                        column: x => x.SecteurId,
                        principalTable: "Secteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 100, nullable: false),
                    PrixUnitaire = table.Column<decimal>(nullable: false),
                    DateLivraison = table.Column<DateTime>(nullable: false),
                    FacturationId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Facturations_FacturationId",
                        column: x => x.FacturationId,
                        principalTable: "Facturations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactAdresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ContactId = table.Column<int>(nullable: false),
                    AdresseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAdresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactAdresses_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactAdresses_Structures_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GrosTitre = table.Column<string>(maxLength: 50, nullable: false),
                    ReviewText = table.Column<string>(maxLength: 2000, nullable: false),
                    StructureId = table.Column<int>(nullable: true),
                    BookId = table.Column<int>(nullable: true),
                    AdresseId = table.Column<int>(nullable: true),
                    AgendaId = table.Column<int>(nullable: true),
                    DepenseId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    ProjetId = table.Column<int>(nullable: true),
                    TelephoneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaires_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaires_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaires_Contacts_BookId",
                        column: x => x.BookId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaires_Depenses_DepenseId",
                        column: x => x.DepenseId,
                        principalTable: "Depenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaires_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaires_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaires_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaires_Telephones_TelephoneId",
                        column: x => x.TelephoneId,
                        principalTable: "Telephones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_SecteurId",
                table: "Adresses",
                column: "SecteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_StructureId",
                table: "Adresses",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_CategorieId",
                table: "Agendas",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_ProjetId",
                table: "Agendas",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_AdresseId",
                table: "Commentaires",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_AgendaId",
                table: "Commentaires",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_BookId",
                table: "Commentaires",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_DepenseId",
                table: "Commentaires",
                column: "DepenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_ItemId",
                table: "Commentaires",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_ProjetId",
                table: "Commentaires",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_StructureId",
                table: "Commentaires",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_TelephoneId",
                table: "Commentaires",
                column: "TelephoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAdresses_AdresseId",
                table: "ContactAdresses",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAdresses_ContactId",
                table: "ContactAdresses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Depenses_ProjetId",
                table: "Depenses",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Depenses_StructureId",
                table: "Depenses",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturations_ProjetId",
                table: "Facturations",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_FacturationId",
                table: "Items",
                column: "FacturationId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetContacts_ContactId",
                table: "ProjetContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_StructureId",
                table: "Projets",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Secteurs_StructureId",
                table: "Secteurs",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_StructureContacts_ContactId",
                table: "StructureContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_SecteurId",
                table: "Telephones",
                column: "SecteurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "ContactAdresses");

            migrationBuilder.DropTable(
                name: "DepenseCategories");

            migrationBuilder.DropTable(
                name: "FacturationCategories");

            migrationBuilder.DropTable(
                name: "ProjetContacts");

            migrationBuilder.DropTable(
                name: "StructureContacts");

            migrationBuilder.DropTable(
                name: "Tauxes");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Depenses");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Telephones");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "AgendaCategories");

            migrationBuilder.DropTable(
                name: "Facturations");

            migrationBuilder.DropTable(
                name: "Secteurs");

            migrationBuilder.DropTable(
                name: "Projets");

            migrationBuilder.DropTable(
                name: "Structures");
        }
    }
}
