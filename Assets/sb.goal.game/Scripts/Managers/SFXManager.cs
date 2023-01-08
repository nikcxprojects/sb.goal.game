using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    [Space(10)]
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip gameOverClip;

    public void GameOver()
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }

        sfxSource.PlayOneShot(gameOverClip);
    }
}
