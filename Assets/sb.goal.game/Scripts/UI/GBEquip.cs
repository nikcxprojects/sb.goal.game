using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class GBEquip : MonoBehaviour
{
    [Space(10)]
    [SerializeField] Transform bootsHover;
    [SerializeField] Transform ballsHover;

    [Space(10)]
    [SerializeField] Transform boots;
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
        bootsHover.transform.position = boots.GetChild(PlayerPrefs.GetInt(Boots.BootsKey)).position;

        foreach (Transform boot in boots)
        {
            boot.GetComponent<Button>().onClick.AddListener(() =>
            {
                bootsHover.position = boot.position;

                PlayerPrefs.SetInt(Boots.BootsKey, boot.GetSiblingIndex());
                PlayerPrefs.Save();

                FindObjectsOfType<MonoBehaviour>().OfType<IMenu>().FirstOrDefault().UpdateMenuIcons();
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

                FindObjectsOfType<MonoBehaviour>().OfType<IMenu>().FirstOrDefault().UpdateMenuIcons();
            });
        }

        backBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }
}
