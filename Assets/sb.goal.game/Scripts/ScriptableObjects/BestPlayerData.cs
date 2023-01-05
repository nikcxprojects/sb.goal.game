using UnityEngine;

[CreateAssetMenu()]
public class BestPlayerData : ScriptableObject
{
    public Sprite icon;
    public string title;

    [TextArea] public string description;
}
