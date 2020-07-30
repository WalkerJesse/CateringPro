using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.WebApi.Extensions;
using CateringPro.WebApi.Interface.Models.Ingredients.CreateIngredient;

namespace CateringPro.WebApi.Infrastructure.Mappings
{

    public class CreateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientProfile()
        {
            _ = this.CreateMap<CreateIngredientCommand, CreateIngredientRequest>()
                .ForMember(dest => dest.MeasurementType, opts => opts.MapFrom(src => src.MeasurementType.ScreamingSnakeCaseToTitleCase(nameof(src.MeasurementType))));

            _ = this.CreateMap<CreateIngredientResponse, CreateIngredientViewModel>()
                .ForMember(dest => dest.MeasurementType, opts => opts.MapFrom(src => src.MeasurementType));
        }

        #endregion Constructors

    }

}
