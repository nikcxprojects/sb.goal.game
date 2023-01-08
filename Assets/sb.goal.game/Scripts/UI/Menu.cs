using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Button footballExpert;
    [SerializeField] Button flyBall;
    [SerializeField] Button guessChampion;

    private void Start()
    {
        footballExpert.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.GoldenBootsMenu, gameObject);
            AppManager.CurrentGameType = GameType.GB;
        });

        flyBall.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.BestPenaltyMenu, gameObject);
            AppManager.CurrentGameType = GameType.BP;
        });

        guessChampion.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.SpeedyMasterMenu, gameObject);
            AppManager.CurrentGameType = GameType.SM;
        });
    }
}
