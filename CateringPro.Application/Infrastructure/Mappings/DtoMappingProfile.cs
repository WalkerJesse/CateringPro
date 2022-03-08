using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Domain.Entities;
using CateringPro.Domain.Enumerations;

namespace CateringPro.Application.Infrastructure.Mappings
{

    public class DtoMappingProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public DtoMappingProfile()
        {
            _ = this.CreateMap<Ingredient, IngredientDto>()
                .ForMember(dest => dest.IngredientID, opts => opts.MapFrom(src => src.ID));

            _ = this.CreateMap<MeasurementType, MeasurementTypeDto>()
                .ForMember(dest => dest.MeasurementID, opts => opts.MapFrom(src => src.Value));

            _ = this.CreateMap<Recipe, RecipeDto>()
                .ForMember(dest => dest.RecipeID, opts => opts.MapFrom(src => src.ID));

            _ = this.CreateMap<RecipeIngredient, RecipeIngredientDto>();
        }

        #endregion Constructors

    }

}
