using System;
using System.Collections.Generic;
using KerberGestaoRegraDeNegocio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KerberGestaoRegraDeNegocio.Data
{
    public partial class kerbergestaoContext : DbContext
    {
        public kerbergestaoContext()
        {
        }

        public kerbergestaoContext(DbContextOptions<kerbergestaoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Orcamento> Orcamentos { get; set; } = null!;
        public virtual DbSet<Projeto> Projetos { get; set; } = null!;
        public virtual DbSet<Ordemservico> Ordemservicos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=kerbergestao;uid=root;pwd=root;connect timeout=90", ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("clientes");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.BairroCliente)
                    .HasMaxLength(45)
                    .HasColumnName("bairroCliente");

                entity.Property(e => e.CelularCliente).HasColumnName("celularCliente");

                entity.Property(e => e.CidadeCliente)
                    .HasMaxLength(45)
                    .HasColumnName("cidadeCliente");

                entity.Property(e => e.CpfCliente).HasColumnName("cpfCliente");

                entity.Property(e => e.EnderecoCliente)
                    .HasMaxLength(45)
                    .HasColumnName("enderecoCliente");

                entity.Property(e => e.EstadoCliente)
                    .HasMaxLength(45)
                    .HasColumnName("estadoCliente");

                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(45)
                    .HasColumnName("nomeCliente");

                entity.Property(e => e.StatusCliente)
                    .HasMaxLength(45)
                    .HasColumnName("statusCliente");

                entity.Property(e => e.TelefoneCliente).HasColumnName("telefoneCliente");
            });

            modelBuilder.Entity<Orcamento>(entity =>
            {
                entity.HasKey(e => e.IdOrcamentos)
                    .HasName("PRIMARY");

                entity.ToTable("orcamentos");

                entity.Property(e => e.IdOrcamentos).HasColumnName("idOrcamentos");

                entity.Property(e => e.NomeOrcamento)
                    .HasMaxLength(45)
                    .HasColumnName("nomeOrcamento");

                entity.Property(e => e.StatusOrcamento).HasColumnName("statusOrcamento");
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto)
                    .HasName("PRIMARY");

                entity.ToTable("projetos");

                entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");

                entity.Property(e => e.NomeProjeto)
                    .HasMaxLength(45)
                    .HasColumnName("nomeProjeto");

                entity.Property(e => e.StatusProjeto).HasColumnName("statusProjeto");
            });

            modelBuilder.Entity<Ordemservico>(entity =>
            {
                entity.HasKey(e => e.IdOrdemServico).HasName("PRIMARY");

                entity.ToTable("ordemservico");

                entity.HasIndex(e => e.IdCliente, "cliente_fk_idx");

                entity.HasIndex(e => e.IdOrcamento, "orcamento_fk_idx");

                entity.Property(e => e.IdOrdemServico).HasColumnName("idOrdemServico");
                entity.Property(e => e.Detalhamento)
                    .HasColumnType("text")
                    .HasColumnName("detalhamento");
                entity.Property(e => e.IdCliente).HasColumnName("idCliente");
                entity.Property(e => e.IdOrcamento).HasColumnName("idOrcamento");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .HasColumnName("titulo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
