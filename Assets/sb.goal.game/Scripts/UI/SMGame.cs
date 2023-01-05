using UnityEngine.UI;
using UnityEngine;

public class SMGame : MonoBehaviour
{
    private int score;
    const int enemyCount = 3;

    [SerializeField] Button pauseBtn;
    [SerializeField] Button settingsBtn;

    [Space(10)]
    [SerializeField] Text scoreText;

    private void OnEnable()
    {
        BallPlayer.OnCollided += OnCollidedEvent;
        BallPlayer.OnLived += OnLivedEvent;
    }

    private void OnDestroy()
    {
        BallPlayer.OnCollided -= OnCollidedEvent;
        BallPlayer.OnLived -= OnLivedEvent;
    }

    private void OnLivedEvent()
    {
        scoreText.text = $"{++score}";

        ScoreUtility.CurrentScore = score;
        ScoreUtility.BestScore = score;
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
            Settings.UpdateOptions(false, true, true);
        });

        Transform parent = GameObject.Find("Environment").transform;

        BallPlayer ballPlyerRef = InstantiateUtility.Spawn<BallPlayer>("ball player", Vector2.down * 3, Quaternion.identity, parent);
        Instantiate(Resources.Load<GameObject>("goal sm"), Vector2.up * 2.2f, Quaternion.identity, parent);

        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 postion = new Vector2(Random.Range(-2.339f, 2.339f), Random.Range(1.84f, 2.346f));
            InstantiateUtility.Spawn<Enemy>("enemy", postion, Quaternion.identity, parent);
        }

        Enemy.Target = ballPlyerRef.transform;
    }

    public static void GameOver()
    {
        Destroy(FindObjectOfType<BallPlayer>().gameObject);
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy e in enemies)
        {
            Destroy(e.gameObject);
        }

        Destroy(GameObject.Find("goal sm(Clone)"));
        Destroy(FindObjectOfType<SMGame>().gameObject);
    }
}
