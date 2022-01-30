using Data;
using UnityEngine;

public static class Extentions
{
  public static T ToDeserialized<T>(this string json)
  {
    return JsonUtility.FromJson<T>(json);
  }

  public static string ToSerialized(this PlayerProgress progress)
  {
    return JsonUtility.ToJson(progress);
  }
}