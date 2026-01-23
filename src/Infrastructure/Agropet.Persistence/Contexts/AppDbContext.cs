using Agropet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agropet.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<FornecedorProduto> FornecedorProduto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<EstoqueProduto> EstoqueProduto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<ItemCompra> ItemCompra { get; set; }
        public DbSet<Configuracao> Configuracao { get; set; }
        public DbSet<MovimentacaoEstoque> MovimentacaoEstoque { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<VendaFormaPagamento> VendaFormaPagamento { get; set; }
        //public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Produtos)
                .HasForeignKey(p => p.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lote>()
                .HasOne(l => l.Produto)
                .WithMany(p => p.Lotes)
                .HasForeignKey(l => l.IdProduto)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FornecedorProduto>()
                .HasOne(fp => fp.Produto)
                .WithMany(p => p.FornecedorProdutos)
                .HasForeignKey(fp => fp.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FornecedorProduto>()
                .HasOne(fp => fp.Fornecedor)
                .WithMany(f => f.FornecedorProdutos)
                .HasForeignKey(fp => fp.IdFornecedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EstoqueProduto>()
                .HasOne(el => el.Estoque)
                .WithMany(e => e.EstoqueProduto)
                .HasForeignKey(el => el.IdEstoque)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EstoqueProduto>()
                .HasOne(ep => ep.Produto)
                .WithMany(p => p.EstoqueProdutos)
                .HasForeignKey(ep => ep.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Compras)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Fornecedor)
                .WithMany(f => f.Compras)
                .HasForeignKey(c => c.IdFornecedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemCompra>()
                .HasOne(ic => ic.Compra)
                .WithMany(c => c.ItensCompras)
                .HasForeignKey(ic => ic.IdCompra)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemCompra>()
                .HasOne(ic => ic.Produto)
                .WithMany(p => p.ItensCompras)
                .HasForeignKey(ic => ic.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fornecedor>()
                .HasOne(f => f.Usuario)
                .WithMany(u => u.Fornecedores)
                .HasForeignKey(f => f.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovimentacaoEstoque>()
                .HasOne(me => me.Produto)
                .WithMany(p => p.MovimentacaoEstoques)
                .HasForeignKey(me => me.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovimentacaoEstoque>()
                .HasOne(me => me.Estoque)
                .WithMany(e => e.MovimentacaoEstoques)
                .HasForeignKey(me => me.IdEstoque)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovimentacaoEstoque>()
                .HasOne(me => me.Compra)
                .WithMany(c => c.MovimentacaoEstoques)
                .HasForeignKey(me => me.IdCompra)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovimentacaoEstoque>()
                .HasOne(me => me.Venda)
                .WithMany(v => v.MovimentacaoEstoques)
                .HasForeignKey(me => me.IdVenda)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovimentacaoEstoque>()
                .HasOne(me => me.Lote)
                .WithMany(l => l.MovimentacaoEstoques)
                .HasForeignKey(me => me.IdLote)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemVenda>()
                .HasOne(pv => pv.Produto)
                .WithMany(p => p.ItemVendas)
                .HasForeignKey(pv => pv.IdProduto)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemVenda>()
                .HasOne(pv => pv.Venda)
                .WithMany(v => v.ItemVendas)
                .HasForeignKey(pv => pv.IdVenda)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VendaFormaPagamento>()
                .HasOne(vfp => vfp.Venda)
                .WithMany(v => v.VendaFormaPagamento)
                .HasForeignKey(vfp => vfp.IdVenda)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VendaFormaPagamento>()
                .HasOne(vfp => vfp.FormaPagamento)
                .WithMany(fp => fp.VendaFormaPagamento)
                .HasForeignKey(vfp => vfp.IdFormaPagamento)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Usuario)
                .WithMany(u => u.Vendas)
                .HasForeignKey(v => v.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Produto>()
            //    .Navigation(p => p.Lotes)
            //    .AutoInclude();

            //modelBuilder.Entity<Usuario>()
            //    .HasIndex(u => u.CPF)
            //    .IsUnique();

            //modelBuilder.Entity<Cliente>()
            //    .HasIndex(c => c.CPF)
            //    .IsUnique();
        }
    }
}
