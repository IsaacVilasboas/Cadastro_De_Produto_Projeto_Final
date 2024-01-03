using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;

namespace ProjetoFinal
{
    public partial class ProjetoFinalContext : DbContext
    {
        public ProjetoFinalContext()
        {
        }

        public ProjetoFinalContext(DbContextOptions<ProjetoFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;initial Catalog=ProjetoFinal;User ID=sa;password=Senha1234#;language=Portuguese;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
        
                entity.HasKey(e => e.Id).HasName("PK__Produtos__4ECCFF3B5901FE9E");

                entity.HasIndex(e => e.CodBarra).IsUnique();

                entity.Property(e => e.CodBarra)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.NomeProduto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Nome_Produto");

                entity.Property(e => e.NomeFornecedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Nome_Fornecedor");

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Qtd)
                    .HasColumnType("integer");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sabor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Recipiente)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastro)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("DataCadastro");

                entity.Property(e => e.Peso)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                
            });

            // Chamada ao método parcial
            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
