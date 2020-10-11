using System;
using back2Front.Models;
using Microsoft.EntityFrameworkCore;

namespace back2Front.Services
{
    public class Back2FrontDBContext : DbContext
    {
        public Back2FrontDBContext(DbContextOptions<Back2FrontDBContext>options) :
            base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Adresse> Adresses { get; set; }
        public virtual DbSet<Agenda> Agendas { get; set; }
        public virtual DbSet<AgendaCategorie> AgendaCategories { get; set; }
        public virtual DbSet<Commentaire> Commentaires { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactAdresse> ContactAdresses { get; set; }
        public virtual DbSet<Depense> Depenses { get; set; }
        public virtual DbSet<DepenseCategorie> DepenseCategories { get; set; }
        public virtual DbSet<Facturation> Facturations { get; set; }
        public virtual DbSet<FacturationCategorie> FacturationCategories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Projet> Projets { get; set; }
        public virtual DbSet<ProjetContact> ProjetContacts { get; set; }
        public virtual DbSet<Secteur> Secteurs { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<StructureContact> StructureContacts { get; set; }
        public virtual DbSet<Taux> Tauxes { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StructureContact>()
                .HasKey(sc => new { sc.StructureId, sc.ContactId });
            modelBuilder.Entity<StructureContact>()
                .HasOne(s => s.Structure)
                .WithMany(sc => sc.Contacts)
                .HasForeignKey(s => s.StructureId);
            modelBuilder.Entity<StructureContact>()
                 .HasOne(c => c.Contact)
                 .WithMany(sc => sc.Structures)
                 .HasForeignKey(c => c.ContactId);

            modelBuilder.Entity<ProjetContact>()
                .HasKey(pc => new { pc.ProjetId, pc.ContactId });
            modelBuilder.Entity<ProjetContact>()
                .HasOne(p => p.Projet)
                .WithMany(pc => pc.Contacts)
                .HasForeignKey(p => p.ProjetId);
            modelBuilder.Entity<ProjetContact>()
                 .HasOne(c => c.Contact)
                 .WithMany(pc => pc.Projets)
                 .HasForeignKey(c => c.ContactId);

        }  

    }
}
