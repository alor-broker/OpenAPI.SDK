namespace Alor.OpenAPI.Utilities
{
    internal class ReadOnlyMemoryComparer : IEqualityComparer<ReadOnlyMemory<byte>>
    {
        public bool Equals(ReadOnlyMemory<byte> x, ReadOnlyMemory<byte> y)
        {
            return x.Span.SequenceEqual(y.Span);
        }

        public int GetHashCode(ReadOnlyMemory<byte> obj)
        {
            var span = obj.Span;
            unchecked
            {
                const int prime = 31;
                var hash = 17;

                for (int i = 0; i < span.Length; i++)
                {
                    hash = hash * prime + span[i];
                }

                return hash;
            }
        }
    }
}
