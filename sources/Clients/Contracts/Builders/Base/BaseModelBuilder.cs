using Clients.Contracts.Base;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Contracts.Builders.Base
{
    public class BaseModelBuilder<TModel> : BaseModelBuilder where TModel : IBaseModel, new()
    {
        public Builder<TModel> Builder { get; }

        protected BaseModelBuilder() => Builder = Builder<TModel>.Create();

        public Builder<TModel> With(Action<TModel> action) => Builder.With(action);

        public TModel Build() => Builder.Build();
    }

    public class BaseModelBuilder
    {
    }
}
