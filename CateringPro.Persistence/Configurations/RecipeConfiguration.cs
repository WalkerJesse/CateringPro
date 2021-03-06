using CateringPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CateringPro.Persistence.Configurations
{

    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {

        #region - - - - - - IEntityTypeConfiguration Implementation - - - - - -

        public void Configure(EntityTypeBuilder<Recipe> entity)
        {
            entity.ToTable("Recipe");

            entity.Property(e => e.ID);

            entity.Property(e => e.Name)
                .IsRequired();
        }

        #endregion IEntityTypeConfiguration Implementation
    }

}
