using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using CateringPro.WebApi.Presentation.Commands.Ingredients;
using CateringPro.WebApi.Presentation.ViewModels.Ingredients;

namespace CateringPro.WebApi.Infrastructure.Mappings.Ingredients
{

    public class IngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public IngredientProfile()
        {
            _ = this.CreateMap<CreateIngredientCommand, CreateIngredientInputPort>();

            _ = this.CreateMap<CreatedIngredientDto, IngredientViewModel>()
                    .ForMember(dest => dest.IngredientID, opts => opts.MapFrom(src => src.IngredientID.Invoke()))
                    .ForMember(dest => dest.IngredientName, opts => opts.MapFrom(src => src.Name));

            _ = this.CreateMap<DeleteIngredientCommand, DeleteIngredientInputPort>();

            _ = this.CreateMap<IngredientDto, IngredientViewModel>()
                    .ForMember(dest => dest.IngredientName, opts => opts.MapFrom(src => src.Name));

            _ = this.CreateMap<UpdateIngredientCommand, UpdateIngredientInputPort>();
        }

        #endregion Constructors

    }

}
