using UnityEngine;

public static class LandscapeUtility
{
    public static Canvas GetLandscape(string gameType)
    {
        return Resources.Load<Canvas>($"Landscapes/{gameType}");
    }
}