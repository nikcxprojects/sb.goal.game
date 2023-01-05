using UnityEngine;

public static class ScoreUtility
{
    public static int CurrentScore
    {
        get => PlayerPrefs.GetInt($"SCORE:{AppManager.CurrentGameType}", 0);
        set => PlayerPrefs.SetInt($"SCORE:{AppManager.CurrentGameType}", value);
    }

    public static int BestScore
    {
        get => PlayerPrefs.GetInt($"BEST SCORE:{AppManager.CurrentGameType}", 0);

        set
        {
            if(CurrentScore > BestScore)
            {
                PlayerPrefs.SetInt($"BEST SCORE:{AppManager.CurrentGameType}", CurrentScore);
                PlayerPrefs.Save();
            }
        }
    }
}
