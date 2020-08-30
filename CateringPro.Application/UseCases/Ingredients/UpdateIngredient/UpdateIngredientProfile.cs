using AutoMapper;
using CateringPro.Domain.Entities;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientProfile : Profile
    {
        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientProfile()
        {
            _ = this.CreateMap<UpdateIngredientRequest, Ingredient>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.IngredientID))
                .ForMember(dest => dest.MeasurementType, opts => opts.MapFrom(src => src.MeasurementType))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name));

            _ = this.CreateMap<Ingredient, UpdateIngredientResponse>();
        }

        #endregion Constructors

    }

}
