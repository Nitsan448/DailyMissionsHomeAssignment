using System;
using System.Collections.Generic;

namespace Core.Extensions
{
    //Generated with AI assistance
    public static class ListExtensions
    {
        /// <summary>
        /// Returns up to <paramref name="count"/> distinct elements in random order. The source is not modified.
        /// </summary>
        public static List<T> GetRandomUniqueElements<T>(this IReadOnlyList<T> source, int count, Random random)
        {
            var elementsPool = new List<T>(source);
            var desiredElementsCount = Math.Min(count, elementsPool.Count);

            // Partial Fisher–Yates: each step swaps a random unpicked element into slot i.
            for (var i = 0; i < desiredElementsCount; i++)
            {
                var pick = random.Next(i, elementsPool.Count);
                (elementsPool[i], elementsPool[pick]) = (elementsPool[pick], elementsPool[i]);
            }

            elementsPool.RemoveRange(desiredElementsCount, elementsPool.Count - desiredElementsCount);
            return elementsPool;
        }
    }
}
