using AutoMapper;
using CateringPro.Domain.Entities;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientProfile()
        {
            _ = this.CreateMap<CreateIngredientRequest, Ingredient>()
                .ForMember(dest => dest.ID, opts => opts.Ignore())
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name));

            _ = this.CreateMap<Ingredient, CreateIngredientResponse>();
        }

        #endregion Constructors

    }

}
