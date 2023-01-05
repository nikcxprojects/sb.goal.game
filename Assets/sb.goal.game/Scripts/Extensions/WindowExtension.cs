using UnityEngine;

public static class WindowExtension
{
    public static Canvas SetLandscape(this GameObject gameObject, Canvas landscape)
    {
        var land = Object.Instantiate(landscape, gameObject.transform);

        land.transform.SetParent(gameObject.transform);
        land.transform.SetAsFirstSibling();

        return land;
    }
}
