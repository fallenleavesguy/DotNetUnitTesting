namespace SimpleApp.Tests
{
    public class Comparer {
        public delegate bool ComparisonDelegate<T>(T? x, T? y);

        public static Comparer<U?> Get<U>(ComparisonDelegate<U?> func) => new Comparer<U?>(func);
    }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private ComparisonDelegate<T> comparisonFunction;

        public Comparer(ComparisonDelegate<T> func)
        {
            comparisonFunction = func;
        }

        public bool Equals(T? x, T? y)
        {
            return comparisonFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }
}
