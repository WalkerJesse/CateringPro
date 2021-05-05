using CateringPro.WebApi.Consumer;
using CateringPro.WebApi.Interface.Ingredients.Commands;
using CateringPro.WebApi.Interface.Ingredients.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebUI.Pages
{

    public partial class Ingredients
    {

        #region - - - - - - Fields - - - - - -

        private CreateIngredientCommand m_CreateIngredientCommand;

        private IngredientViewModel m_IngredientViewModel;

        #endregion Fields

        #region - - - - - - Properties - - - - - -

        [Inject]
        private IngredientsApi m_IngredientsApi { get; set; }

        #endregion Properties

        #region - - - - - - ComponentBase Implementation - - - - - -

        protected override void OnInitialized()
        {
            this.m_IngredientViewModel = new IngredientViewModel();
            this.InitialiseCreateIngredientCommand();
        }

        #endregion ComponentBase Implementation

        #region - - - - - - Methods - - - - - -

        private async Task CreateNewIngredientAsync()
        {
            var _ApiResponse = await this.m_IngredientsApi.AddIngredientAsync(this.m_CreateIngredientCommand, CancellationToken.None);
            if (_ApiResponse.Response != null)
            {
                this.m_IngredientViewModel = _ApiResponse.Response;
                this.InitialiseCreateIngredientCommand();
            }
        }

        private async Task DeleteIngredientAsync()
        {
            var _ApiResponse = await this.m_IngredientsApi.DeleteIngredientAsync(new DeleteIngredientCommand(), this.m_IngredientViewModel.IngredientID, CancellationToken.None);
            if (_ApiResponse.Response != null)
            {
                this.m_IngredientViewModel = new IngredientViewModel();
            }
        }

        private void InitialiseCreateIngredientCommand()
            => this.m_CreateIngredientCommand = new CreateIngredientCommand();

        #endregion Methods

    }

}
