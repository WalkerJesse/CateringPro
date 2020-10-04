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

            _ = this.CreateMap<Ingredient, CreateIngredientResponse>()
                .ForMember(dest => dest.IngredientID, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.IngredientName, opts => opts.MapFrom(src => src.Name));
        }

        #endregion Constructors

    }

}
