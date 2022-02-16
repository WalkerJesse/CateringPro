using AutoMapper;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.WebApi.Interface.Recipes.Commands;
using CateringPro.WebApi.Interface.Recipes.ViewModels;

namespace CateringPro.WebApi.Infrastructure.Mappings.Recipes
{

    public class CreateRecipeProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeProfile()
        {
            _ = this.CreateMap<CreateRecipeCommand, CreateRecipeInputPort>();

            _ = this.CreateMap<ICreateRecipeOutputPort, RecipeViewModel>()
                    .ForMember(dest => dest.RecipeID, opts => opts.MapFrom(src => src.RecipeID.Invoke()));
        }

        #endregion Constructors

    }

}
