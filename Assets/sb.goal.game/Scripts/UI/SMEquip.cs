using UnityEngine.UI;
using UnityEngine;

public class SMEquip : MonoBehaviour
{
    [Space(10)]
    [SerializeField] Transform shirtsHover;
    [SerializeField] Transform ballsHover;

    [Space(10)]
    [SerializeField] Transform shirts;
    [SerializeField] Transform balls;

    [Space(10)]
    [SerializeField] Button backBtn;

    private void OnEnable()
    {
        AppManager.IsEquip = true;
    }

    private void OnDestroy()
    {
        AppManager.IsEquip = false;
    }

    private void Start()
    {
        shirtsHover.transform.position = shirts.GetChild(PlayerPrefs.GetInt(Shirts.ShirtKey)).position;

        foreach (Transform shirt in shirts)
        {
            shirt.GetComponent<Button>().onClick.AddListener(() =>
            {
                shirtsHover.position = shirt.position;

                PlayerPrefs.SetInt(Shirts.ShirtKey, shirt.GetSiblingIndex());
                PlayerPrefs.Save();
            });
        }

        ballsHover.transform.position = balls.GetChild(PlayerPrefs.GetInt(Balls.BallKey)).position;

        foreach (Transform ball in balls)
        {
            ball.GetComponent<Button>().onClick.AddListener(() =>
            {
                ballsHover.position = ball.position;

                PlayerPrefs.SetInt(Balls.BallKey, ball.GetSiblingIndex());
                PlayerPrefs.Save();
            });
        }

        backBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }
}
