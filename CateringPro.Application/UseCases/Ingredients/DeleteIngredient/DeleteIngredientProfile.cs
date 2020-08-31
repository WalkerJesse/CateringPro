using AutoMapper;
using CateringPro.Domain.Entities;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public DeleteIngredientProfile()
        {
            _ = this.CreateMap<Ingredient, DeleteIngredientResponse>();
        }

        #endregion Constructors

    }

}
