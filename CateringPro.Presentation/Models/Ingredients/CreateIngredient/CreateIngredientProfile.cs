using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Presentation.Extensions;

namespace CateringPro.Presentation.Models.Ingredients.CreateIngredient
{

    public class CreateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientProfile()
        {
            _ = this.CreateMap<CreateIngredientCommand, CreateIngredientRequest>()
                .ForMember(dest => dest.MeasurementType, opts => opts.MapFrom(src => src.MeasurementType.ScreamingSnakeCaseToTitleCase(nameof(src.MeasurementType))));

            _ = this.CreateMap<CreateIngredientResponse, CreateIngredientViewModel>();
        }

        #endregion Constructors

    }

}
