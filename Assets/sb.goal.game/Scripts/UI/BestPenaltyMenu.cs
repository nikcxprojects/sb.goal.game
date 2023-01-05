using UnityEngine.UI;
using UnityEngine;

public class BestPenaltyMenu : MonoBehaviour, IMenu
{
    [SerializeField] Button startBtn;
    [SerializeField] Button equipmentBtn;
    [SerializeField] Button settingsBtn;

    [Space(10)]
    [SerializeField] Image currentBall;
    [SerializeField] GameObject VFX;

    private void Start()
    {
        VFX.SetActive(true);

        startBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.BPGame, gameObject);
        });

        equipmentBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.BPEquip);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Settings);
            Settings.UpdateOptions(false, true, false);
        });

        UpdateMenuIcons();

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

    public void UpdateMenuIcons()
    {
        currentBall.sprite = Resources.Load<Sprite>($"Balls/{PlayerPrefs.GetInt(Balls.BallKey)}");
    }
}
