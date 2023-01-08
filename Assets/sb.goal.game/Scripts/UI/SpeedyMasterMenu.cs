using UnityEngine.UI;
using UnityEngine;

public class SpeedyMasterMenu : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button settingsBtn;
    [SerializeField] Button menuBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.SMGame, gameObject);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Settings);
        });

        menuBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Menu, gameObject);
        });

        var landscapeTemplate = LandscapeUtility.GetLandscape(AppManager.CurrentGameType);
        var canvasRef = gameObject.SetLandscape(landscapeTemplate);
        canvasRef.overrideSorting = false;
    }
}
