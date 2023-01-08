using UnityEngine;

public class BallLoading : MonoBehaviour
{
    private const float force = 25;
    private Vector2 LastVelocity { get; set; }
    private Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = Vector2.zero;
        Rigidbody.velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)).normalized * force;
    }

    private void Update()
    {
        LastVelocity = Rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = Vector2.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        Rigidbody.velocity = direction * Mathf.Max(force, force);
    }
}
