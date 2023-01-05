using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    [Space(10)]
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip gameOverClip;

    private void Awake()
    {
        BootPlayer.OnCollided += () =>
        {
            if (sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }

            sfxSource.PlayOneShot(hitClip);
        };

        BallPenalty.OnPressed += () =>
        {
            if (sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }

            sfxSource.PlayOneShot(hitClip);
        };

        BallPlayer.OnCollided += () =>
        {
            if (sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }

            sfxSource.PlayOneShot(hitClip);
        };
    }

    public void GameOver()
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }

        sfxSource.PlayOneShot(gameOverClip);
    }
}
