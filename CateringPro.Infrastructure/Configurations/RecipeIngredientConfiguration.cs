//using CateringPro.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace CateringPro.Infrastructure.Configurations
//{
//    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
//    {

//        #region - - - - - - IEntityTypeConfiguration Implementation - - - - - -

//        public void Configure(EntityTypeBuilder<RecipeIngredient> entity)
//        {
//            entity.ToTable("RecipeIngredient");

//            entity.Property(e => e.Amount)
//                .IsRequired();

//            entity.Property<long>("IngredientID");
//            entity.HasOne(e => e.Ingredient)
//                .WithMany()
//                .HasForeignKey("ID")
//                .IsRequired();

//            entity.Property(e => e.MeasurementType)
//                .HasConversion(i => i.Value, dbval => dbval)
//                .IsRequired();

//            entity.Property<long>("RecipeID");
//            entity.HasOne(e => e.Recipe)
//                .WithMany(e => e.Ingredients)
//                .HasForeignKey("ID")
//                .IsRequired();

//            entity.HasKey("IngredientID", "RecipeID");
//        }

//        #endregion IEntityTypeConfiguration Implementation

//    }

//}
