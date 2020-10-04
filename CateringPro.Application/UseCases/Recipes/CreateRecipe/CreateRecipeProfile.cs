using AutoMapper;
using CateringPro.Domain.Entities;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeProfile()
        {
            _ = this.CreateMap<CreateRecipeRequest, Recipe>()
                .ForMember(dest => dest.ID, opts => opts.Ignore())
                .ForMember(dest => dest.Ingredients, opts => opts.Ignore())
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name));

            _ = this.CreateMap<Recipe, CreateRecipeResponse>();
        }

        #endregion Constructors

    }

}
