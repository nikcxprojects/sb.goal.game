using UnityEngine;

public class SourceContainer : MonoBehaviour
{
    private void Start()
    {
        GetComponent<AudioSource>().mute = PlayerPrefs.GetInt(gameObject.name) == 0;
    }
}
