using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PersonPhoneApp
{
    public partial class PersonphonenumberContext : DbContext
    {
        public PersonphonenumberContext()
        {
        }

        public PersonphonenumberContext(DbContextOptions<PersonphonenumberContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=laptop-jceo3ssa\\sqlexpress;Initial Catalog=PersonPhoneNumber;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.Type).IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.Personid)
                    .HasConstraintName("FK_Phone_Person1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}