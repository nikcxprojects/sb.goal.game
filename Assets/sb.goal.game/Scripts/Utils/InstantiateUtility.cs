using UnityEngine;
public static class InstantiateUtility
{
    public static T Spawn<T>(string objectName, Vector2 postion, Quaternion rotation, Transform parent) where T :  MonoBehaviour
    {
        return Object.Instantiate(Resources.Load<T>(objectName), postion, rotation, parent);
    }
}
