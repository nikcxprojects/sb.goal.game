using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Button resumeBtn;

    private void OnEnable()
    {
        AppManager.IsPause = true;
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        AppManager.IsPause = false;
        Time.timeScale = 1;
    }

    private void Start()
    {
        resumeBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }
}
