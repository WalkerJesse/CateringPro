using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.WebApi.Extensions;
using CateringPro.WebApi.Interface.Ingredients.Commands;
using CateringPro.WebApi.Interface.Ingredients.ViewModels;

namespace CateringPro.WebApi.Infrastructure.Mappings
{

    public class CreateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientProfile()
        {
            _ = this.CreateMap<CreateIngredientCommand, CreateIngredientRequest>()
                .ForMember(dest => dest.MeasurementType, opts => opts.MapFrom(src => src.MeasurementType.ScreamingSnakeCaseToTitleCase(nameof(src.MeasurementType))));

            _ = this.CreateMap<CreateIngredientResponse, IngredientViewModel>()
                .ForMember(dest => dest.MeasurementType, opts => opts.MapFrom(src => src.MeasurementType));
        }

        #endregion Constructors

    }

}
