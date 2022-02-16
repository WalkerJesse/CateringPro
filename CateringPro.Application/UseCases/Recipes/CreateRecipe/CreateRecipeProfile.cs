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
            _ = this.CreateMap<CreateRecipeInputPort, Recipe>()
                    .ForMember(dest => dest.ID, opts => opts.Ignore())
                    .ForMember(dest => dest.Ingredients, opts => opts.Ignore());

            _ = this.CreateMap<Recipe, CreatedRecipeDto>()
                    .ForMember(dest => dest.RecipeID, opts => opts.MapFrom(src => new Func<long>(() => src.ID)));
        }

        #endregion Constructors

    }

}
