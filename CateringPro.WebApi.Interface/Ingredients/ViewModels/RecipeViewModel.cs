namespace CateringPro.WebApi.Interface.Recipes.ViewModels
{

    /// <summary>
    /// The View Model of a Recipe
    /// </summary>
    public class RecipeViewModel
    {

        #region - - - - - - Properties - - - - - -

        /// <summary>
        /// The ID of the Recipe
        /// </summary>
        public long RecipeID { get; set; }

        /// <summary>
        /// The Name of the Recipe
        /// </summary>
        public string RecipeName { get; set; }

        #endregion Properties

    }

}
