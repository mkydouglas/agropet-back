using Agropet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agropet.Persistence.Configurations;

public class MemberDatabaseInitialization : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasOne(p => p.Usuario)
                .WithMany(u => u.Produtos)
                .HasForeignKey(p => p.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
    }
}
