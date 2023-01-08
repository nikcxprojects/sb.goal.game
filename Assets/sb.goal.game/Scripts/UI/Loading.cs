using System.Collections;
using UnityEngine;

public class Loading : MonoBehaviour
{
    private IEnumerator Start()
    {
        float et = 0.0f;
        float loadingTime = Random.Range(2.25f, 4.5f);

        int loadingBallCount = 3;
        BallLoading ballLoadingPrefab = Resources.Load<BallLoading>("ballLoading");
        for(int i = 0; i < loadingBallCount; i++)
        {
            Instantiate(ballLoadingPrefab, null);
        }

        while(et < loadingTime)
        {
            et += Time.deltaTime;
            yield return null;
        }

        BallLoading[] ballLoadings = FindObjectsOfType<BallLoading>();
        foreach(BallLoading ballLoading in ballLoadings)
        {
            Destroy(ballLoading.gameObject);
        }

        UIManager.OpenWindow(Window.Menu, gameObject);
    }
}
