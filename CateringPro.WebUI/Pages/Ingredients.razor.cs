using CateringPro.WebApi.Consumer;
using CateringPro.WebApi.Interface.Models.Ingredients.CreateIngredient;
using Microsoft.AspNetCore.Components;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebUI.Pages
{

    public partial class Ingredients
    {

        #region - - - - - - Fields - - - - - -

        private CreateIngredientCommand m_CreateIngredientCommand;

        private CreateIngredientViewModel m_CreateIngredientViewModel;

        #endregion Fields

        #region - - - - - - Properties - - - - - -

        [Inject]
        private IngredientsApi m_IngredientsApi { get; set; }

        #endregion Properties

        #region - - - - - - ComponentBase Implementation - - - - - -

        protected override async Task OnInitializedAsync()
        {
            this.InitialiseCreateIngredientCommand();
        }

        #endregion ComponentBase Implementation

        #region - - - - - - Methods - - - - - -

        private async Task CreateNewIngredient()
        {
            var _ApiResponse = await this.m_IngredientsApi.AddIngredientAsync(this.m_CreateIngredientCommand, CancellationToken.None);
            if (_ApiResponse.Response != null)
            {
                this.m_CreateIngredientViewModel = _ApiResponse.Response;
                this.InitialiseCreateIngredientCommand();
            }
        }

        private void InitialiseCreateIngredientCommand()
            => this.m_CreateIngredientCommand = new CreateIngredientCommand();

        #endregion Methods

    }

}
