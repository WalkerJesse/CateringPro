﻿using AutoMapper;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.WebApi.Interface.Recipes.Commands;
using CateringPro.WebApi.Interface.Recipes.ViewModels;

namespace CateringPro.WebApi.Infrastructure.Mappings.Recipes
{

    public class CreateRecipeProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeProfile()
        {
            _ = this.CreateMap<CreateRecipeCommand, CreateRecipeRequest>();

            _ = this.CreateMap<CreateRecipeResponse, RecipeViewModel>()
                .ForMember(dest => dest.RecipeID, opts => opts.Ignore())
                .ForMember(dest => dest.RecipeName, opts => opts.Ignore());
        }

        #endregion Constructors

    }

}
