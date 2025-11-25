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
        public DbSet<FornecedorLote> FornecedorLote { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<EstoqueLote> EstoqueLote { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<ItemCompra> ItemCompra { get; set; }
        //public DbSet<MovimentacaoEstoque> MovimentacaoEstoque { get; set; }
        //public DbSet<Venda> Venda { get; set; }
        //public DbSet<ProdutoVenda> ProdutoVenda { get; set; }
        //public DbSet<FormaPagamento> FormaPagamento { get; set; }
        //public DbSet<VendaFormaPagamento> VendaFormaPagamento { get; set; }
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

            modelBuilder.Entity<FornecedorLote>()
                .HasOne(fl => fl.Lote)
                .WithMany(l => l.FornecedorLote)
                .HasForeignKey(fl => fl.IdLote)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FornecedorLote>()
                .HasOne(fl => fl.Fornecedor)
                .WithMany(l => l.FornecedorLote)
                .HasForeignKey(fl => fl.IdFornecedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EstoqueLote>()
                .HasOne(el => el.Estoque)
                .WithMany(e => e.EstoqueLote)
                .HasForeignKey(el => el.IdEstoque)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EstoqueLote>()
                .HasOne(el => el.Lote)
                .WithMany(l => l.EstoqueLote)
                .HasForeignKey(el => el.IdLote)
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

            //modelBuilder.Entity<Lote>()
            //    .HasOne(l => l.Fornecedor)
            //    .WithMany(f => f.Lotes)
            //    .HasForeignKey(l => l.IdFornecedor);

            //modelBuilder.Entity<MovimentacaoEstoque>()
            //    .HasOne(m => m.Lote)
            //    .WithMany(l => l.MovimentacaoEstoques)
            //    .HasForeignKey(m => m.IdLote)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ProdutoVenda>()
            //    .HasOne(pv => pv.Produto)
            //    .WithMany(p => p.ProdutoVendas)
            //    .HasForeignKey(pv => pv.IdProduto)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ProdutoVenda>()
            //    .HasOne(pv => pv.Venda)
            //    .WithMany(v => v.ProtudoVendas)
            //    .HasForeignKey(pv => pv.IdVenda)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<VendaFormaPagamento>()
            //    .HasOne(vfp => vfp.Venda)
            //    .WithMany(v => v.VendaFormaPagamento)
            //    .HasForeignKey(vfp => vfp.IdVenda)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<VendaFormaPagamento>()
            //    .HasOne(vfp => vfp.FormaPagamento)
            //    .WithMany(fp => fp.VendaFormaPagamento)
            //    .HasForeignKey(vfp => vfp.IdFormaPagamento)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Produto>()
            //    .Navigation(p => p.Lotes)
            //    .AutoInclude();

            //modelBuilder.Entity<Venda>()
            //    .HasOne(v => v.Usuario)
            //    .WithMany(u => u.Vendas)
            //    .HasForeignKey(v => v.IdUsuario)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Usuario>()
            //    .HasIndex(u => u.CPF)
            //    .IsUnique();

            //modelBuilder.Entity<Cliente>()
            //    .HasIndex(c => c.CPF)
            //    .IsUnique();
        }
    }
}
