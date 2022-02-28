using CleanArchitecture.Mediator;

namespace CateringPro.Application.Infrastructure.Authorisation
{

    public class AuthorisationResult : IAuthorisationResult
    {

        #region - - - - - - Constructors - - - - - -

        public AuthorisationResult() { }

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public string FailureReason { get; private set; }

        public bool IsAuthorised
            => string.IsNullOrEmpty(this.FailureReason);

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        public static AuthorisationResult Failure(string unauthorisedReason)
            => new() { FailureReason = unauthorisedReason };

        public static AuthorisationResult Success()
            => new();

        #endregion Methods

    }

}
