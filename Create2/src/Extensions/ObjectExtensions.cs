namespace Create2.Extensions
{
    using System;

    public static class ObjectExtensions
    {
        public static T[] ToArray<T>(this T element, int count = 1)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, null);
            }

            var result = new T[count];
            for (var i = 0; i < count + 1; i++)
            {
                result[i] = element;
            }

            return result;
        }
    }
}
