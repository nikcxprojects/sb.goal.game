using UnityEngine.UI;
using UnityEngine;

public class SpeedyMasterMenu : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button equipmentBtn;
    [SerializeField] Button settingsBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.SMGame, gameObject);
        });

        equipmentBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.SMEquip);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Settings);
            Settings.UpdateOptions(false, true, true);
        });

        var landscapeTemplate = LandscapeUtility.GetLandscape(AppManager.CurrentGameType);
        var canvasRef = gameObject.SetLandscape(landscapeTemplate);
        canvasRef.overrideSorting = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Settings.IsOpened && !AppManager.IsEquip)
        {
            UIManager.OpenWindow(Window.Menu, gameObject);
        }
    }
}
