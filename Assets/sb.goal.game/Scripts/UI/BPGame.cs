using UnityEngine.UI;
using UnityEngine;

public class BPGame : MonoBehaviour
{
    private static BPGame Instance { get => FindObjectOfType<BPGame>(); }

    private int score;

    private float nextFire;
    private const float fireRate = 0.5f;

    [SerializeField] Button pauseBtn;
    [SerializeField] Button settingsBtn;

    private static GameObject LevelRef { get; set; }
    private static GameObject BallPlayerRef { get; set; }


    private GameObject LevelPrefab { get; set; }
    private GameObject BallPlayerPrefab { get; set; }



    [Space(10)]
    [SerializeField] Text scoreText;

    [Space(10)]
    [SerializeField] float speed;

    private void Awake()
    {
        LevelPrefab = Resources.Load<GameObject>("level");
        BallPlayerPrefab = Resources.Load<GameObject>("ball player");
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

        BallPlayerRef = Instantiate(BallPlayerPrefab, GameObject.Find("Environment").transform);
        BallPlayerRef.transform.position = new Vector2(-1.8f, 0);
    }

    private void Update()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            scoreText.text = $"{++score}";

            ScoreUtility.CurrentScore = score;
            ScoreUtility.BestScore = score;
        }

        LevelRef.transform.position += speed * Time.deltaTime * Vector3.left;
    }

    public static void GameOver()
    {
        Destroy(LevelRef);
        Destroy(BallPlayerRef);

        UIManager.OpenWindow(Window.GameOver, Instance.gameObject);
    }
}
