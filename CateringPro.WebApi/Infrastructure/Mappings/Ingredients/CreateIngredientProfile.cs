using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.WebApi.Interface.Ingredients.Commands;
using CateringPro.WebApi.Interface.Ingredients.ViewModels;

namespace CateringPro.WebApi.Infrastructure.Mappings.Ingredients
{

    public class CreateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientProfile()
        {
            _ = this.CreateMap<CreateIngredientCommand, CreateIngredientRequest>();

            _ = this.CreateMap<CreateIngredientResponse, IngredientViewModel>()
                    .ForMember(dest => dest.IngredientID, opts => opts.MapFrom(src => src.IngredientID.Invoke()));
        }

        #endregion Constructors

    }

}
