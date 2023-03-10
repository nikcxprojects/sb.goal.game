using UnityEngine;
using UnityEngine.UI;

public class GBGame : MonoBehaviour
{
    private int id;
    private int score;

    [SerializeField] Button pauseBtn;
    [SerializeField] Button settingsBtn;

    [Space(10)]
    [SerializeField] Text scoreText;

    [Space(10)]
    [SerializeField] Text questionText;
    [SerializeField] Image iconImage;
    [SerializeField] Transform ansvers;

    [Space(10)]
    [SerializeField] HealthContainer healthContainer;
    [SerializeField] FootballExpertData data;

    private void OnEnable()
    {
        id = 0;
        UpdateQuestion();
    }

    private void Awake()
    {
        foreach(Transform t in ansvers)
        {
            Button ansver = t.GetComponent<Button>();
            ansver.onClick.AddListener(() =>
            {
                if (Switcher.VibraEnabled)
                {
                    Handheld.Vibrate();
                }

                int selectId = t.GetSiblingIndex();
                int ansverId = data.questionDatas[id].ansverId;

                bool IsTrue = selectId == ansverId;
                if(IsTrue)
                {
                    scoreText.text = $"{++score}";

                    ScoreUtility.CurrentScore = score;
                    ScoreUtility.BestScore = score;
                }
                else
                {
                    bool IsGameEnd = healthContainer.TakeDamage();
                    if(IsGameEnd)
                    {
                        UIManager.OpenWindow(Window.GameOver, gameObject);
                        return;
                    }
                }

                id++;
                if(id > data.questionDatas.Length - 1)
                {
                    UIManager.OpenWindow(Window.GameOver, gameObject);
                    return;
                }

                UpdateQuestion();
            });
        }
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
    }

    private void UpdateQuestion()
    {
        questionText.text = $"{data.questionDatas[id].question}";
        iconImage.sprite = data.questionDatas[id].icon;

        for(int i = 0; i < ansvers.childCount; i++)
        {
            Text ansver = ansvers.GetChild(i).GetChild(0).GetComponent<Text>();
            ansver.text = i switch
            {
                0 => data.questionDatas[id].a,
                1 => data.questionDatas[id].b,
                2 => data.questionDatas[id].c,
                3 => data.questionDatas[id].d,
            };
        }
    }
}
