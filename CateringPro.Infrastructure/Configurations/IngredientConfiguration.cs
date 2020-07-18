using CateringPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CateringPro.Infrastructure.Configurations
{

    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {

        #region - - - - - - IEntityTypeConfiguration Implementation - - - - - -

        public void Configure(EntityTypeBuilder<Ingredient> entity)
        {
            entity.ToTable("Ingredient");

            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID)
                .HasColumnName("IngredientID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.MeasurementType)
                .HasConversion(i => i.Value, dbval => dbval)
                .IsRequired();

            entity.Property(e => e.Name)
                .IsRequired();
        }

        #endregion IEntityTypeConfiguration Implementation
    }

}
