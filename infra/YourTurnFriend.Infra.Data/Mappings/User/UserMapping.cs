using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserEntity = YourTurnFriend.Domain.Entities.User.User;

namespace YourTurnFriend.Infra.Data.Mappings.User;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("YTF_USER");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
                .HasColumnName("ID")
                .HasConversion(
                    value => value.ToString().ToLower(),
                    valueDb => Guid.Parse(valueDb)
                );

        builder.Property(u => u.Username)
                .HasColumnName("USERNAME")
                .IsRequired()
                .HasMaxLength(50);

        builder.Property(u => u.Password)
                .HasColumnName("PASSWORD")
                .IsRequired()
                .HasMaxLength(8);

        builder.Property(u => u.CreatedAt)
                .HasColumnName("CREATED_AT")
                .HasConversion(
                    value => value.ToString(),
                    valueDb => DateTime.Parse(valueDb)
                )
                .IsRequired();

        builder.Property(u => u.LastUpdatedAt)
            .IsRequired(false)
            .HasConversion(
                    value => value.ToString(),
                    valueDb => !string.IsNullOrEmpty(valueDb) 
                                ? DateTime.Parse(valueDb)
                                : null
                )
                .HasColumnName("LAST_UPDATED_AT");
    }
}