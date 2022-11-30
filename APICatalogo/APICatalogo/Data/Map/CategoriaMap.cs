using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICatalogo.Data.Map;

public class CategoriaMap : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(x => x.CategoriaId);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
    }
}
