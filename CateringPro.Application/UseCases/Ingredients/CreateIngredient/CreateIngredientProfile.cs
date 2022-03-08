using AutoMapper;
using CateringPro.Domain.Entities;
using System;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientProfile()
        {
            _ = this.CreateMap<CreateIngredientInputPort, Ingredient>()
                    .ForMember(dest => dest.ID, opts => opts.Ignore());

            _ = this.CreateMap<Ingredient, CreatedIngredientDto>()
                    .ForMember(dest => dest.IngredientID, opts => opts.MapFrom(src => new Func<long>(() => src.ID)));
        }

        #endregion Constructors

    }

}
