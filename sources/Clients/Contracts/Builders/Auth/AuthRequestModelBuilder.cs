using Clients.Contracts.Auth;
using Clients.Contracts.Builders.Base;

namespace Clients.Contracts.Builders.Auth
{
    public class AuthRequestModelBuilder: BaseModelBuilder<AuthRequestModel>
    {
        public static AuthRequestModelBuilder Instance => new();

        public AuthRequestModelBuilder WithCreds(string userName, string password)
        {
            Builder
             .With(x => x.UserName = userName)
             .With(x => x.Password = password);
            return this;
        }
    }
}
