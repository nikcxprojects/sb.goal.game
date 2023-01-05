using UnityEngine;

public static class UIManager
{
    public static void OpenWindow(string window, GameObject lastWindow = null)
    {
        WindowUtility.TryGetWindow(window, (window) =>
        {
            Object.Instantiate(window, GameObject.Find("main canvas").transform);
        });

        if(lastWindow)
        {
            Object.Destroy(lastWindow);
        }
    }
}