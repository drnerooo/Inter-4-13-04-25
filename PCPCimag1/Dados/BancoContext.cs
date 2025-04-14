using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCPCimag1.Models;

namespace PCPCimag1.Dados
{
    public class BancoContext :DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){ }
        public DbSet<Apontamento> Apontamentos{ get; set; }
        public DbSet<Funcionario> Funcionarios{ get; set; }
        public DbSet<Operacao> Operacoes {get; set; } 
        public DbSet<Operador> Operadores {get; set; }
        public DbSet<OrdemDeProducao> OPs {get; set; }
        public DbSet<PCP> PCPs {get; set; }
        public DbSet<Peca> Pecas {get; set; }
        public DbSet<PecaOperacao> PecaOperacoes {get; set; }
        public DbSet<Subprodutos> Subprodutoss {get; set; }
        public DbSet<Superprodutos> Superprodutoss {get; set; }
        public DbSet<TipoDeOperacao> TipoDeOperacoes {get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apontamento>(t=> {
                t.ToTable("Apontamentos");
                t.HasKey(t=>t.Id);
                t.Property(t=>t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Quantidade).HasColumnType("int").IsRequired();
                t.Property(t => t.Inicio).HasColumnType("Datetime").IsRequired();
                t.Property(t => t.Fim).HasColumnType("Datetime").IsRequired();
                t.HasOne(t => t.operacao).WithMany(t => t.Apontamentos).OnDelete(DeleteBehavior.NoAction).IsRequired();
                t.HasMany(t => t.operador).WithMany(t => t.Apontamentos);
                t.HasOne(t => t.OrdemDeProducao).WithOne(t => t.Apontamentos).OnDelete(DeleteBehavior.NoAction).IsRequired();
            });

            modelBuilder.Entity<Funcionario>(t =>
            {
                t.ToTable("Funcionario");
                t.HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Nome).HasColumnType("varchar(128)").IsRequired();
                t.Property(t => t.Login).HasColumnType("varchar(64)").IsRequired();
                t.Property(t => t.Senha).HasColumnType("varchar(128)").IsRequired();
                t.HasMany(t => t.PCPs).WithOne(t => t.Funcionario).OnDelete(DeleteBehavior.NoAction).IsRequired();
                t.HasMany(t => t.Operadores).WithOne(t => t.Funcionario).OnDelete(DeleteBehavior.NoAction).IsRequired();
            });

            modelBuilder.Entity<Operacao>(t =>
            {
                t.ToTable("Operacoes");
                t.HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Descricao).HasColumnType("varchar(256)").IsRequired();
                t.HasOne(t => t.TipoDeOperacao).WithMany(t => t.Operacoes).OnDelete(DeleteBehavior.NoAction).IsRequired();
                t.HasMany(t => t.Apontamentos).WithOne(t => t.operacao).OnDelete(DeleteBehavior.NoAction).IsRequired();
                t.HasMany(t => t.PecaOperacaoes).WithOne(t => t.Operacao).OnDelete(DeleteBehavior.NoAction).IsRequired();
            });
            modelBuilder.Entity<Operador>(t =>
            {
                t.ToTable("Operadores");
                t.HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.HasOne(t => t.Funcionario).WithMany(t => t.Operadores).OnDelete(DeleteBehavior.NoAction).IsRequired();
                t.HasMany(t => t.Apontamentos).WithMany(t => t.operador);
            });
            modelBuilder.Entity<OrdemDeProducao>(t =>
            {
                t.ToTable("OPs");
                t.HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Quantidade).HasColumnType("int").IsRequired();
                t.Property(t => t.DataEmissao).HasColumnType("Datetime").IsRequired();
                t.HasOne(t => t.peca).WithMany(t => t.Ops).OnDelete(DeleteBehavior.NoAction).IsRequired();
                t.HasMany(t => t.PCPEmissor).WithMany(t => t.ODP);
                t.HasOne(t => t.Apontamentos).WithOne(t => t.OrdemDeProducao).OnDelete(DeleteBehavior.NoAction).IsRequired();
            });
            modelBuilder.Entity<PCP>(t =>
            {
                t.ToTable("PCPs");
                t.HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.HasOne(t => t.Funcionario).WithMany(t => t.PCPs).IsRequired().OnDelete(DeleteBehavior.NoAction);
                t.HasMany(t => t.ODP).WithMany(t => t.PCPEmissor);
            });
            modelBuilder.Entity<Peca>(t =>
            {
                t.ToTable("Pecas");
                t.HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Descricao).HasColumnType("string").IsRequired();
                t.Property(t => t.Data_Cadastro).HasColumnType("Datetime");
                t.Property(t => t.Valor).HasColumnType("double");
                t.Property(t => t.Situacao).HasColumnType("bool");
                t.Property(t => t.Imagem).HasColumnType("string");
                t.HasMany(t => t.Ops).WithOne(t => t.peca);
                t.HasMany(t => t.PecaOperacoes).WithOne(t => t.Peca);
                t.HasMany(t => t.Subprodutos).WithOne(t => t.Pecaref);
            });
            modelBuilder.Entity<PecaOperacao>(t =>
            {
                t.ToTable("PecaOperacoes");
                t.HasOne(t => t.Peca).WithMany(t => t.PecaOperacoes);
                t.HasOne(t => t.Operacao).WithMany(t => t.PecaOperacaoes);
                t.Property(t => t.etapa).HasColumnType("int").IsRequired();

            });
        }
    }
}
