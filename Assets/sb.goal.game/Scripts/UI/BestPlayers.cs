using UnityEngine;
using UnityEngine.UI;

public class BestPlayers : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text titleText;
    [SerializeField] Text descriptionText;

    [Space(10)]
    [SerializeField] GameObject detailsGo;
    [SerializeField] GameObject buttonsGo;

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
        });
    }

    public void OpenPlayer(BestPlayerData bestPlayerData)
    {
        backBtn.gameObject.SetActive(true);

        icon.sprite = bestPlayerData.icon;
        titleText.text = bestPlayerData.title;
        descriptionText.text = bestPlayerData.description;

        buttonsGo.SetActive(false);
        detailsGo.SetActive(true);
    }
}
