namespace Core.Extensions
{
    public static class CollectionsExtensions
    {
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary.TryGetValue(key, out var value))
                return value;

            throw new KeyNotFoundException($"Key '{key}' was not found in the dictionary.");
        }
    }
}
