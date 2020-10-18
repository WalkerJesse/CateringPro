using AutoMapper;
using CateringPro.Domain.Entities;
using System.Collections.Generic;

namespace CateringPro.Application.UseCases.Recipes.GetRecipes
{

    public class GetRecipesProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public GetRecipesProfile()
        {
            _ = this.CreateMap<List<RecipeDto>, GetRecipesResponse>()
                .ForMember(dest => dest.Recipes, opts => opts.MapFrom(src => src));

            _ = this.CreateMap<Recipe, RecipeDto>()
                .ForMember(dest => dest.RecipeID, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.RecipeName, opts => opts.MapFrom(src => src.Name));
        }

        #endregion Constructors

    }

}
