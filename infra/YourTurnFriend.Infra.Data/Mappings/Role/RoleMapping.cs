using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using YourTurnFriend.Domain.Constantes.Role;
using EntityRole = YourTurnFriend.Domain.Entities.Role.Role;

namespace YourTurnFriend.Infra.Data.Mappings.Role;

internal sealed class RoleMapping : IEntityTypeConfiguration<EntityRole>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EntityRole> builder)
    {
        builder.ToTable("YTF_ROLE");

        builder.HasKey(r => r.Id);

        builder.HasIndex(r => r.Name);

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .ValueGeneratedNever()
            .HasConversion(
                value => value.ToString().ToLower(),
                valueDb => Guid.Parse(valueDb)
            );

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("NAME");

        builder.HasData(
        [
            EntityRole.Create(RoleNameCST.DEFAULT),
            EntityRole.Create(RoleNameCST.ADMIN)
        ]);
    }
}