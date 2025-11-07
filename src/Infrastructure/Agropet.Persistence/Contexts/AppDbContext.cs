using Agropet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agropet.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public DbSet<Produto> Produto { get; set; }
        //public DbSet<Lote> Lote { get; set; }
        //public DbSet<MovimentacaoEstoque> MovimentacaoEstoque { get; set; }
        //public DbSet<Fornecedor> Fornecedor { get; set; }
        //public DbSet<Venda> Venda { get; set; }
        //public DbSet<ProdutoVenda> ProdutoVenda { get; set; }
        //public DbSet<FormaPagamento> FormaPagamento { get; set; }
        //public DbSet<VendaFormaPagamento> VendaFormaPagamento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<Cliente> Cliente { get; set; }
        //public DbSet<Estoque> Estoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lote>()
                .HasOne(l => l.Produto)
                .WithMany(p => p.Lotes)
                .HasForeignKey(l => l.IdProduto)
                .IsRequired();

            modelBuilder.Entity<Lote>()
                .HasOne(l => l.Fornecedor)
                .WithMany(f => f.Lotes)
                .HasForeignKey(l => l.IdFornecedor);

            modelBuilder.Entity<MovimentacaoEstoque>()
                .HasOne(m => m.Lote)
                .WithMany(l => l.MovimentacaoEstoques)
                .HasForeignKey(m => m.IdLote)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProdutoVenda>()
                .HasOne(pv => pv.Produto)
                .WithMany(p => p.ProdutoVendas)
                .HasForeignKey(pv => pv.IdProduto)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProdutoVenda>()
                .HasOne(pv => pv.Venda)
                .WithMany(v => v.ProtudoVendas)
                .HasForeignKey(pv => pv.IdVenda)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VendaFormaPagamento>()
                .HasOne(vfp => vfp.Venda)
                .WithMany(v => v.VendaFormaPagamento)
                .HasForeignKey(vfp => vfp.IdVenda)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VendaFormaPagamento>()
                .HasOne(vfp => vfp.FormaPagamento)
                .WithMany(fp => fp.VendaFormaPagamento)
                .HasForeignKey(vfp => vfp.IdFormaPagamento)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Produto>()
                .Navigation(p => p.Lotes)
                .AutoInclude();

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
