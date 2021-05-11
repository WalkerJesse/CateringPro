using AutoMapper;
using CateringPro.Domain.Entities;
using System;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeProfile()
        {
            _ = this.CreateMap<CreateRecipeRequest, Recipe>()
                    .ForMember(dest => dest.ID, opts => opts.Ignore())
                    .ForMember(dest => dest.Ingredients, opts => opts.Ignore());

            _ = this.CreateMap<Recipe, CreateRecipeResponse>()
                    .ForMember(dest => dest.RecipeID, opts => opts.MapFrom(src => new Func<long>(() => src.ID)))
                    .ForMember(dest => dest.RecipeName, opts => opts.MapFrom(src => src.Name));
        }

        #endregion Constructors

    }

}
