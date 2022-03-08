using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.WebApi.Presentation.Commands.Recipes;
using CateringPro.WebApi.Presentation.ViewModels.RecipeIngredients;
using CateringPro.WebApi.Presentation.ViewModels.Recipes;

namespace CateringPro.WebApi.Infrastructure.Mappings.Recipes
{

    public class RecipeProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public RecipeProfile()
        {
            _ = this.CreateMap<CreateRecipeCommand, CreateRecipeInputPort>();

            _ = this.CreateMap<CreatedRecipeDto, RecipeViewModel>()
                    .ForMember(dest => dest.Ingredients, opts => opts.Ignore())
                    .ForMember(dest => dest.RecipeID, opts => opts.MapFrom(src => src.RecipeID.Invoke()))
                    .ForMember(dest => dest.RecipeName, opts => opts.MapFrom(src => src.Name));

            _ = this.CreateMap<RecipeDto, RecipeViewModel>()
                    .ForMember(dest => dest.Ingredients, opts => opts.MapFrom(src => src.Ingredients))
                    .ForMember(dest => dest.RecipeName, opts => opts.MapFrom(src => src.Name));

            _ = this.CreateMap<RecipeIngredientDto, RecipeIngredientViewModel>()
                    .ForMember(dest => dest.IngredientID, opts => opts.MapFrom(src => src.Ingredient.IngredientID))
                    .ForMember(dest => dest.MeasurementType, opts => opts.MapFrom(src => src.MeasurementType.Name));
        }

        #endregion Constructors

    }

}
