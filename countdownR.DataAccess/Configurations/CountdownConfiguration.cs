using countdownR.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace countdownR.DataAccess.Configurations;

public class CountdownConfiguration : IEntityTypeConfiguration<Countdown>
{
    public void Configure(EntityTypeBuilder<Countdown> builder)
    {
        //builder.Property(c => c.Title)
        //    .HasMaxLength(50)
        //    .IsRequired();

        //builder.Property(c => c.Date)
        //    .IsRequired();

        //builder.Property(c => c.Subtitle)
        //    .HasMaxLength(50);

        //builder.Property(c=>c.DigitsColor)
    }
}
