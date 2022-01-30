using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ClearPrefs
    {
        [MenuItem("Tools/ClearPrefs")]
        private static void ShowWindow()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}