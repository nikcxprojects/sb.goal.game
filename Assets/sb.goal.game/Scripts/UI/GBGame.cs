using UnityEngine;
using UnityEngine.UI;

public class GBGame : MonoBehaviour
{
    private int score;

    [SerializeField] Button pauseBtn;
    [SerializeField] Button settingsBtn;

    [Space(10)]
    [SerializeField] Text scoreText;

    private void OnEnable()
    {
        BootPlayer.OnCollided += OnCollidedEvent;

        var landscapeTemplate = LandscapeUtility.GetLandscape(AppManager.CurrentGameType);
        var canvasRef = gameObject.SetLandscape(landscapeTemplate);
        canvasRef.overrideSorting = true;
    }

    private void OnDestroy()
    {
        BootPlayer.OnCollided -= OnCollidedEvent;
    }

    private void OnCollidedEvent()
    {
        if (Switcher.VibraEnabled)
        {
            Handheld.Vibrate();
        }

        scoreText.text = $"{++score}";

        ScoreUtility.CurrentScore = score;
        ScoreUtility.BestScore = score;
    }

    private void Start()
    {
        ScoreUtility.CurrentScore = score;

        pauseBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Pause);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Settings);
            Settings.UpdateOptions(true, true, false);
        });

        Transform parent = GameObject.Find("Environment").transform;

        Ball ballRef = InstantiateUtility.Spawn<Ball>("ball", Vector2.up * 6, Quaternion.identity, parent);
        InstantiateUtility.Spawn<BootPlayer>("boot player", Vector2.down * 3.688f, Quaternion.identity, parent);
        InstantiateUtility.Spawn<OverZone>("over zone", Vector2.down * 5, Quaternion.identity, parent);

        BootPlayer.BallRef = ballRef;
    }

    public static void GameOver()
    {
        Destroy(FindObjectOfType<GBGame>().gameObject);
        Destroy(FindObjectOfType<BootPlayer>().gameObject);
        Destroy(FindObjectOfType<OverZone>().gameObject);
        Destroy(FindObjectOfType<Ball>().gameObject);
    }
}
