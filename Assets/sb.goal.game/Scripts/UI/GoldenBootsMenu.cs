using UnityEngine.UI;
using UnityEngine;

public class GoldenBootsMenu : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button settingsBtn;
    [SerializeField] Button menuBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.GBGame, gameObject);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Settings);
            Settings.UpdateOptions(true, true, false);
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
