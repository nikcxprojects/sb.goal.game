using UnityEngine.UI;
using UnityEngine;

public class BPGame : MonoBehaviour
{
    private int score;

    [SerializeField] Button pauseBtn;
    [SerializeField] Button settingsBtn;

    [Space(10)]
    [SerializeField] Text scoreText;
    [SerializeField] GameObject VFX;

    [Space(10)]
    [SerializeField] Transform rating;
    [SerializeField] Sprite fill;
    [SerializeField] Sprite empty;

    private void OnEnable()
    {
        BallPenalty.OnTravelled += OnTravelldEvent;
    }

    private void OnDestroy()
    {
        BallPenalty.OnTravelled -= OnTravelldEvent;
    }

    private void OnTravelldEvent()
    {
        if(Switcher.VibraEnabled)
        {
            Handheld.Vibrate();
        }

        scoreText.text = $"{++score}";

        ScoreUtility.CurrentScore = score;
        ScoreUtility.BestScore = score;

        SetRating();
    }

    private void SetRating()
    {
        SetRatingZero();
        rating.gameObject.SetActive(true);

        int count = Random.Range(1, rating.childCount);
        for(int i = 0; i < count; i++)
        {
            rating.GetChild(i).GetComponent<Image>().sprite = fill;
        }
    }

    private void SetRatingZero()
    {
        foreach(Transform t in rating)
        {
            t.GetComponent<Image>().sprite = empty;
        }
    }

    private void Start()
    {
        VFX.SetActive(true);
        rating.gameObject.SetActive(false);

        ScoreUtility.CurrentScore = score;

        pauseBtn.onClick.AddListener(() =>
        {
            rating.gameObject.SetActive(false);
            UIManager.OpenWindow(Window.Pause);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            rating.gameObject.SetActive(false);

            UIManager.OpenWindow(Window.Settings);
            Settings.UpdateOptions(false, true, false);
        });

        Transform parent = GameObject.Find("Environment").transform;

        Instantiate(Resources.Load<GameObject>("goal"), Vector2.zero, Quaternion.identity, parent);
        Instantiate(Resources.Load<GameObject>("place"), Vector2.down * 3.47f, Quaternion.identity, parent);
        InstantiateUtility.Spawn<BallPenalty>("ball penalty", Vector2.zero, Quaternion.identity, parent);
    }

    public static void GameOver()
    {
        Destroy(FindObjectOfType<BPGame>().gameObject);
        Destroy(FindObjectOfType<BallPenalty>().gameObject);

        Destroy(GameObject.Find("goal(Clone)"));
        Destroy(GameObject.Find("place(Clone)"));
    }
}
