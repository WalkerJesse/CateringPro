// <auto-generated />
using CateringPro.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CateringPro.Persistence.Migrations
{
    [DbContext(typeof(PersistenceContext))]
    partial class PersistenceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("CateringPro.Domain.Entities.Ingredient", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("CateringPro.Domain.Entities.Recipe", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("CateringPro.Domain.Entities.RecipeIngredient", b =>
                {
                    b.Property<decimal>("Measurement")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IngredientID")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MeasurementType")
                        .HasColumnType("INTEGER");

                    b.Property<long>("RecipeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("RecipeID", "IngredientID");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("CateringPro.Domain.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("CateringPro.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CateringPro.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
