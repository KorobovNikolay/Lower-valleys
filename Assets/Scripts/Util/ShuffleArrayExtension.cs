using System;
using System.Collections;
using System.Collections.Generic;

public static class ShuffleArrayExtension
{
    public static void Shuffle<T>(this List<T> list)
    {
        Random randomIndex = new Random();

        for (var i = list.Count - 1; i >= 1; i--)
        {
            var j = randomIndex.Next(i + 1);

            T temp = list[j];
            list[j] = list[i];
            list[i] = temp;
        }
    }
}
