﻿using System;
using System.Collections.Generic;

namespace Brain
{
  public static class Utility
  {
    private static Random random = new Random();

    public static void SetSeed(int seed)
    {
      random = new Random(seed);
    }

    public static int RandomInt(int maxValue)
    {
      return random.Next(maxValue);
    }

    public static int RandomInt(int minValue, int maxValue)
    {
      return random.Next(minValue, maxValue);
    }

    public static int[] RandomUniqueInts(int count, int minValue, int maxValue)
    {
      var a = new int[count];
      var list = new List<int>();

      for (var i = minValue; i < maxValue; i++) {
        list.Add(i);
      }

      for (var i = 0; i < count; i++) {
        var idx = RandomInt(list.Count);
        a[i] = list[idx];
        list.RemoveAt(idx);
      }

      return a;
    }

    public static double RandomDouble()
    {
      return random.NextDouble();
    }

    public static double RandomDouble(double min, double max)
    {
      return min + RandomDouble() * (max - min);
    }

    public static bool RandomBoolean()
    {
      return random.Next(2) == 0;
    }

    public static T[] RemoveElement<T>(T[] array, int index)
    {
      var a = new T[array.Length - 1];
      var j = 0;

      for (var i = 0; i < array.Length; i++) {
        if (i != index) {
          a[j] = array[i];
          j++;
        }
      }

      return a;
    }

    public static List<T> Flatten<T>(List<List<T>> list)
    {
      var flat = new List<T>();

      for (var i = 0; i < list.Count; i++) {
        for (var j = 0; j < list[i].Count; j++) {
          flat.Add(list[i][j]);
        }
      }

      return flat;
    }

    public static IList<T> Shuffle<T>(IList<T> list)
    {
      var n = list.Count;

      while (n > 1) {
        n--;
        var k = random.Next(n + 1);
        var e = list[k];
        list[k] = list[n];
        list[n] = e;
      }

      return list;
    }

    public static int RoundToInt(double x)
    {
      return (int) System.Math.Round(x);
    }
  }
}