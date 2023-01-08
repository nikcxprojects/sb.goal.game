using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static bool IsOpened { get; private set; }

    [SerializeField] Button backBtn;
    private static Transform options;

    private void OnEnable()
    {
        IsOpened = true;
    }

    private void OnDestroy()
    {
        IsOpened = false;
    }

    private void Awake()
    {
        options = transform.Find("optional");
    }

    private void Start()
    {
        backBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }

    public static void UpdateOptions(bool boots, bool balls, bool shirts)
    {
        options.GetChild(0).gameObject.SetActive(boots);
        options.GetChild(1).gameObject.SetActive(balls);
        options.GetChild(2).gameObject.SetActive(shirts);
    }
}
