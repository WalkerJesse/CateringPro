using AutoMapper;
using CateringPro.Domain.Entities;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientProfile()
        {
            _ = this.CreateMap<Ingredient, UpdateIngredientResponse>();

            _ = this.CreateMap<UpdateIngredientRequest, Ingredient>()
                    .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ID))
                    .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name));
        }

        #endregion Constructors

    }

}
