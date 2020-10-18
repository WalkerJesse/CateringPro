using AutoMapper;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.WebApi.Extensions;
using CateringPro.WebApi.Interface.Recipes.Commands;
using CateringPro.WebApi.Interface.Recipes.ViewModels;

namespace CateringPro.WebApi.Infrastructure.Mappings.Recipes
{

    public class CreateRecipeProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeProfile()
        {
            _ = this.CreateMap<CreateRecipeCommand, CreateRecipeRequest>();

            _ = this.CreateMap<CreateRecipeResponse, RecipeViewModel>()
                .ForMember(dest => dest.RecipeID, opts => opts.Ignore())
                .ForMember(dest => dest.RecipeName, opts => opts.Ignore());

            _ = this.CreateMap<RecipeIngredientViewModel, RecipeIngredientDto>()
                .ForMember(dest => dest.MeasurementType, opts => opts.MapFrom(src => src.MeasurementType.ScreamingSnakeCaseToTitleCase(nameof(src.MeasurementType))));
        }

        #endregion Constructors

    }

}
