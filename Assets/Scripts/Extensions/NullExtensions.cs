#nullable enable
using System;

namespace Extensions
{
    public static class NullExtensions
    {
        public static T EnsureNotNull<T>(this T? value, string? message = null)
        {
            if (value == null)
            {
                throw new NullReferenceException(
                    message ?? $"Object of type {typeof(T).Name} is not found"
                );
            }

            return value;
        }
    }
}