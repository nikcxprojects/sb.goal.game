using UnityEngine.UI;
using UnityEngine;

public class BPGame : MonoBehaviour
{
    private static BPGame Instance { get => FindObjectOfType<BPGame>(); }

    private int score;

    [SerializeField] Button pauseBtn;
    [SerializeField] Button settingsBtn;

    private static GameObject LevelRef { get; set; }
    private GameObject LevelPrefab { get; set; }

    [Space(10)]
    [SerializeField] Text scoreText;

    [Space(10)]
    [SerializeField] float speed;

    private void Awake()
    {
        LevelPrefab = Resources.Load<GameObject>("level");
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
        });

        LevelRef = Instantiate(LevelPrefab, GameObject.Find("Environment").transform);
        LevelRef.transform.position = new Vector2(38.3f, 0);
    }

    private void OnEnable()
    {
        
    }

    private void OnDestroy()
    {
        
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

    public static void GameOver()
    {
        Destroy(LevelRef);
        UIManager.OpenWindow(Window.GameOver, Instance.gameObject);
    }
}
