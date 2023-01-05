using System;
using UnityEngine;

public static class WindowUtility
{
    public static void TryGetWindow(string window, Action<GameObject> callback)
    {
        callback?.Invoke(Resources.Load<GameObject>($"UI/{window}"));
    }
}
