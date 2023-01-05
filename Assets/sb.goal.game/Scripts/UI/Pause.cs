using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Button resumeBtn;

    private void OnEnable()
    {
        var landscapeTemplate = LandscapeUtility.GetLandscape(AppManager.CurrentGameType);
        var canvasRef = gameObject.SetLandscape(landscapeTemplate);
        canvasRef.overrideSorting = false;

        AppManager.IsPause = true;
    }

    private void OnDestroy()
    {
        AppManager.IsPause = false;
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
        foreach (Enemy e in enemies)
        {
            e.Sleep();
        }

        resumeBtn.onClick.AddListener(() =>
        {
            if (FindObjectOfType<Ball>() != null)
            {
                Ball.WakeUp();
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
}
