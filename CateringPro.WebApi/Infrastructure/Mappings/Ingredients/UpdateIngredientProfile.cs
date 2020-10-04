using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using CateringPro.WebApi.Interface.Ingredients.Commands;

namespace CateringPro.WebApi.Infrastructure.Mappings.Ingredients
{

    public class UpdateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientProfile()
        {
            _ = this.CreateMap<UpdateIngredientCommand, UpdateIngredientRequest>()
                .ForMember(dest => dest.ID, opts => opts.Ignore());
        }

        #endregion Constructors

    }

}
