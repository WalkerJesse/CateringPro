using AutoMapper;
using CateringPro.Domain.Entities;
using System.Collections.Generic;

namespace CateringPro.Application.UseCases.Ingredients.GetIngredients
{

    public class GetIngredientsProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public GetIngredientsProfile()
        {
            _ = this.CreateMap<Ingredient, IngredientDto>()
                    .ForMember(dest => dest.IngredientID, opts => opts.MapFrom(src => src.ID))
                    .ForMember(dest => dest.IngredientName, opts => opts.MapFrom(src => src.Name));

            _ = this.CreateMap<List<IngredientDto>, GetIngredientsResponse>()
                    .ForMember(dest => dest.Ingredients, opts => opts.MapFrom(src => src));
        }

        #endregion Constructors

    }

}
