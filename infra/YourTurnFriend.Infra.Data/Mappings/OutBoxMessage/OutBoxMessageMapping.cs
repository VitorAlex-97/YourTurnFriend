using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity = YourTurnFriend.Infra.Data.OutBox.OutBoxMessage;

namespace YourTurnFriend.Infra.Data.Mappings.OutBoxMessage;

public class OutBoxMessageMapping : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> builder)
    {
        builder.ToTable("YTF_OUT_BOX_MESSAGE");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .HasConversion(
                value => value.ToString().ToLower(),
                valueDb => Guid.Parse(valueDb)
            );

        builder.Property(x => x.Type)
            .HasColumnName("TYPE")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Content)
            .HasColumnName("CONTENT")
            .IsRequired();

        builder.Property(x => x.OcurredOn)
            .HasColumnName("OCURRED_ON")
            .IsRequired()
            .HasConversion(
                value => value.ToString(),
                valueDb => DateTime.Parse(valueDb)
            );

        builder.Property(o => o.ProcessedOn)
            .IsRequired(false)
            .HasColumnName("PROCESSED_ON")
            .HasConversion(
                value => value.ToString(),
                valueDb => !string.IsNullOrEmpty(valueDb) 
                            ? DateTime.Parse(valueDb)
                            : null
            );
    }
}