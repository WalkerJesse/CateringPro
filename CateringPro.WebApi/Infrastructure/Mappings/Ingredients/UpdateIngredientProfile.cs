using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using CateringPro.WebApi.Extensions;
using CateringPro.WebApi.Interface.Ingredients.Commands;

namespace CateringPro.WebApi.Infrastructure.Mappings.Ingredients
{

    public class UpdateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientProfile()
        {
            _ = this.CreateMap<UpdateIngredientCommand, UpdateIngredientRequest>()
                .ForMember(dest => dest.IngredientID, opts => opts.Ignore())
                .ForMember(dest => dest.MeasurementType, opts => opts.MapFrom(src => src.MeasurementType.ScreamingSnakeCaseToTitleCase(nameof(src.MeasurementType))));
        }

        #endregion Constructors

    }

}
