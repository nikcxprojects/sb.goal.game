using UnityEngine;

public class OverZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BPGame.GameOver();
    }
}