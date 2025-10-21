namespace Clients.Contracts.Builders.Base
{
    public class BuilderFactory<TBuilder> where TBuilder: BaseModelBuilder
    {
        public static TBuilder Instance => (TBuilder)Activator.CreateInstance(typeof(TBuilder));
    }
}
