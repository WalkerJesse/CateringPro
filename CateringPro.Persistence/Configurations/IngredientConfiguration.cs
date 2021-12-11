using CateringPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CateringPro.Persistence.Configurations
{

    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {

        #region - - - - - - IEntityTypeConfiguration Implementation - - - - - -

        public void Configure(EntityTypeBuilder<Ingredient> entity)
        {
            entity.ToTable("Ingredient");

            entity.Property(e => e.ID);

            entity.Property(e => e.Name)
                .IsRequired();
        }

        #endregion IEntityTypeConfiguration Implementation
    }

}
