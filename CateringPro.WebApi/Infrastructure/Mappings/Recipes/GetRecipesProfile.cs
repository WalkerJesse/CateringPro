using AutoMapper;
using CateringPro.Application.UseCases.Recipes.GetRecipes;
using CateringPro.WebApi.Interface.Recipes.Queries;
using CateringPro.WebApi.Interface.Recipes.ViewModels;

namespace CateringPro.WebApi.Infrastructure.Mappings.Recipes
{

    public class GetRecipesProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public GetRecipesProfile()
        {
            _ = this.CreateMap<GetRecipesQuery, GetRecipesRequest>();

            _ = this.CreateMap<GetRecipesResponse, RecipesViewModel>();

            _ = this.CreateMap<RecipeDto, RecipeViewModel>();
        }

        #endregion Constructors

    }

}
