using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Button resumeBtn;

    private void OnEnable()
    {
        var landscapeTemplate = LandscapeUtility.GetLandscape(AppManager.CurrentGameType);
        var canvasRef = gameObject.SetLandscape(landscapeTemplate);
        canvasRef.overrideSorting = false;

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
