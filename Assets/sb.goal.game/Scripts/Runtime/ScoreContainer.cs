using UnityEngine;
using UnityEngine.UI;

public class ScoreContainer : MonoBehaviour
{
    [SerializeField] string key;
    private void OnEnable()
    {
        if (string.Equals(key, "CurrentScore"))
        {
            GetComponent<Text>().text = $"{ScoreUtility.CurrentScore}";
        }
        else
        {
            GetComponent<Text>().text = $"{ScoreUtility.BestScore}";
        }
    }
}
