using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Button resumeBtn;

    private void OnEnable()
    {
        AppManager.IsPause = true;
    }

    private void OnDestroy()
    {
        AppManager.IsPause = false;
    }

    private void Start()
    {
        resumeBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }
}
