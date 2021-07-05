using System;
using app.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace app.api.DbContexts
{
    public partial class SIMECContext : DbContext
    {
        public SIMECContext()
        {
        }

        public SIMECContext(DbContextOptions<SIMECContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Detallefactura> Detallefacturas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=SIMEC; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente);

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Idcliente)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("IDCLIENTE");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Nombrecompleto)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECOMPLETO");
            });

            modelBuilder.Entity<Detallefactura>(entity =>
            {
                entity.HasKey(e => e.Iddetalle)
                    .IsClustered(false);

                entity.ToTable("DETALLEFACTURA");

                entity.Property(e => e.Iddetalle).HasColumnName("IDDETALLE");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Idfactura).HasColumnName("IDFACTURA");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Subtotal).HasColumnName("SUBTOTAL");

                entity.HasOne(d => d.IdfacturaNavigation)
                    .WithMany(p => p.Detallefacturas)
                    .HasForeignKey(d => d.Idfactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLEF_RELATIONS_FACTURA");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Detallefacturas)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLEF_RELATIONS_PRODUCTO");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Idfactura);

                entity.ToTable("FACTURA");

                entity.Property(e => e.Idfactura).HasColumnName("IDFACTURA");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Idcliente)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("IDCLIENTE");

                entity.Property(e => e.Total).HasColumnName("TOTAL");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACTURA_RELATIONS_CLIENTE");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto);

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
