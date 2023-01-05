using UnityEngine;
using UnityEngine.UI;

public class FootBallRules : MonoBehaviour
{
    [SerializeField] Text titleText;
    [SerializeField] Text descriptionText;

    [Space(10)]
    [SerializeField] GameObject detailsGo;
    [SerializeField] GameObject buttonsGo;
    [SerializeField] GameObject cupGo;

    [Space(10)]
    [SerializeField] Button menuBtn;
    [SerializeField] Button backBtn;

    private void Start()
    {
        backBtn.gameObject.SetActive(false);
        detailsGo.SetActive(false);

        menuBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Menu, gameObject);
        });

        backBtn.onClick.AddListener(() =>
        {
            backBtn.gameObject.SetActive(false);
            detailsGo.SetActive(false);

            buttonsGo.SetActive(true);
            cupGo.SetActive(true);
        });
    }

    public void OpenRule(FootBallRuleData footBallRuleData)
    {
        backBtn.gameObject.SetActive(true);

        titleText.text = footBallRuleData.title;
        descriptionText.text = footBallRuleData.description;

        buttonsGo.SetActive(false);
        cupGo.SetActive(false);

        detailsGo.SetActive(true);
    }
}
