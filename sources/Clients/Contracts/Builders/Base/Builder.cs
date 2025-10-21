using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Contracts.Builders.Base
{
    public class Builder<T> where T : new()
    {
        private readonly List<Action<T>> _customizations = new();

        public static Builder<T> Create() => new Builder<T>();

        public Builder<T> With(Action<T> action)
        {
            _customizations.Add(action);
            return this;
        }

        public T Build()
        {
            var obj = new T();
            foreach (var customization in _customizations)
            {
               customization(obj);
            }
            return obj;
        }
    }
}
