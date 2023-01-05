using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static bool IsOpened { get; private set; }

    [SerializeField] Button backBtn;
    private static Transform options;

    [Space(10)]
    [SerializeField] Button bootsBtn;
    [SerializeField] Button ballsBtn;
    [SerializeField] Button shirtsBtn;

    private void OnEnable()
    {
        IsOpened = true;
    }

    private void OnDestroy()
    {
        IsOpened = false;
    }

    private void Awake()
    {
        options = transform.Find("optional");
    }

    private void Start()
    {
        if (FindObjectOfType<Ball>() != null)
        {
            Ball.Sleep();
        }

        if (FindObjectOfType<BallPenalty>() != null)
        {
            BallPenalty.Sleep();
        }

        if (FindObjectOfType<BallPlayer>() != null)
        {
            BallPlayer.Sleep();
        }

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy e in enemies)
        {
            e.Sleep();
        }

        bootsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Boots);
        });

        ballsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Balls);
        });

        shirtsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Shirts);
        });

        backBtn.onClick.AddListener(() =>
        {
            if (FindObjectOfType<Ball>() != null)
            {
                Ball.WakeUp();
                BootPlayer.UpdateRender();
            }

            if (FindObjectOfType<BallPenalty>() != null)
            {
                BallPenalty.WakeUp();
            }

            if (FindObjectOfType<BallPlayer>() != null)
            {
                BallPlayer.WakeUp();
            }

            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy e in enemies)
            {
                e.WakeUp();
            }

            Destroy(gameObject);
        });
    }

    public static void UpdateOptions(bool boots, bool balls, bool shirts)
    {
        options.GetChild(0).gameObject.SetActive(boots);
        options.GetChild(1).gameObject.SetActive(balls);
        options.GetChild(2).gameObject.SetActive(shirts);
    }
}
