using UnityEngine.UI;
using UnityEngine;

public class GoldenBootsMenu : MonoBehaviour, IMenu
{
    [SerializeField] Button startBtn;
    [SerializeField] Button equipmentBtn;
    [SerializeField] Button settingsBtn;

    [Space(10)]
    [SerializeField] Image currentBoots;
    [SerializeField] Image currentBall;

    private void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.GBGame, gameObject);
        });

        equipmentBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.GBEquip);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Settings);
            Settings.UpdateOptions(true, true, false);
        });

        UpdateMenuIcons();

        var landscapeTemplate = LandscapeUtility.GetLandscape(AppManager.CurrentGameType);
        var canvasRef = gameObject.SetLandscape(landscapeTemplate);
        canvasRef.overrideSorting = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !Settings.IsOpened && !AppManager.IsEquip)
        {
            UIManager.OpenWindow(Window.Menu, gameObject);
        }
    }

    public void UpdateMenuIcons()
    {
        currentBoots.sprite = Resources.Load<Sprite>($"Boots/{PlayerPrefs.GetInt(Boots.BootsKey)}");
        currentBall.sprite = Resources.Load<Sprite>($"Balls/{PlayerPrefs.GetInt(Balls.BallKey)}");
    }
}
