using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static bool IsOpened { get; private set; }
    [SerializeField] Button backBtn;

    private void OnEnable()
    {
        IsOpened = true;
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        IsOpened = false;
        Time.timeScale = 1;
    }

    private void Start()
    {
        backBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }
}
