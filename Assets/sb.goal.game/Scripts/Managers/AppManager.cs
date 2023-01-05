using UnityEngine;

public class AppManager : MonoBehaviour
{
    public static string CurrentGameType { get; set; }

    public static bool IsEquip { get; set; }

    public static bool IsPause { get; set; }

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
        }

        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 1);
        }

        if (!PlayerPrefs.HasKey("vibration"))
        {
            PlayerPrefs.SetInt("vibration", 1);
            Switcher.VibraEnabled = true;
        }
        else
        {
            Switcher.VibraEnabled = PlayerPrefs.GetInt("vibration") > 0;
        }
    }
}
