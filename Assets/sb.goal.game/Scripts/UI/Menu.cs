using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Button goldenBoots;
    [SerializeField] Button bestPenalty;
    [SerializeField] Button speedyMaster;

    [Space(10)]
    [SerializeField] Button footballRulesBtn;
    [SerializeField] Button bestPlayersBtn;

    [Space(10)]
    [SerializeField] GameObject VFX;

    private void Start()
    {
        VFX.SetActive(true);

        goldenBoots.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.GoldenBootsMenu, gameObject);
            AppManager.CurrentGameType = GameType.GB;
        });

        bestPenalty.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.BestPenaltyMenu, gameObject);
            AppManager.CurrentGameType = GameType.BP;
        });

        speedyMaster.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.SpeedyMasterMenu, gameObject);
            AppManager.CurrentGameType = GameType.SM;
        });

        footballRulesBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.FootballRules, gameObject);
        });

        bestPlayersBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.BestPlayers, gameObject);
        });
    }
}
