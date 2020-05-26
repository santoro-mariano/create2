namespace Create2.Extensions
{
    using System;

    public static class ArrayExtensions
    {
        public static T[] Shift<T>(this T[] source, T value)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new T[source.Length + 1];
            result[0] = value;
            Array.Copy(source, 0, result, 1, source.Length);
            return result;
        }
    }
}
