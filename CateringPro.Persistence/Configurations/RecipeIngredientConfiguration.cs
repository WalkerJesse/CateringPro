using CateringPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CateringPro.Persistence.Configurations
{
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {

        #region - - - - - - IEntityTypeConfiguration Implementation - - - - - -

        public void Configure(EntityTypeBuilder<RecipeIngredient> entity)
        {
            entity.ToTable("RecipeIngredient");

            entity.HasKey("RecipeID", "IngredientID");

            entity.Property<long>("IngredientID");
            entity.HasOne(e => e.Ingredient)
                .WithMany()
                .HasForeignKey("IngredientID")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.Property(e => e.Measurement)
                .IsRequired();

            entity.Property(e => e.MeasurementType)
                .HasConversion(mt => mt.Value, dbval => dbval)
                .IsRequired();

            entity.Property<long>("RecipeID");
            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.Ingredients)
                .HasForeignKey("RecipeID")
                .IsRequired();
        }

        #endregion IEntityTypeConfiguration Implementation

    }

}
