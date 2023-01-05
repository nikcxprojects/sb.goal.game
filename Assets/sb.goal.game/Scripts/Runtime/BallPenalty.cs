using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class BallPenalty : MonoBehaviour
{
    private Vector2 InitScale { get; set; } = Vector3.one * 0.35f;
    private Vector2 TargetScale { get; set; } = Vector3.one * 0.1f;

    private Transform Center { get; set; }
    private Transform Target { get; set; }

    private GameObject Shadow { get; set; }

    private const float totalDistance = 4.0f;
    private const float force = 20;

    private static Rigidbody2D Rigidbody { get; set; }
    private static Vector2 Velocity { get; set; }

    private static SpriteRenderer SpriteRenderer { get; set; }

    private bool EndTravel { get; set; }
    public static Action OnTravelled { get; set; }
    public static Action OnPressed { get; set; }

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateRender();
    }

    private void Start()
    {
        Center = GameObject.Find("center").transform;
        Target = GameObject.Find("target").transform;
        Shadow = GameObject.Find("shadow");

        Rigidbody = GetComponent<Rigidbody2D>();

        ResetMe();
    }

    private void OnMouseDown()
    {
        if(Rigidbody.velocity.sqrMagnitude > 0 || Settings.IsOpened || AppManager.IsEquip || AppManager.IsPause)
        {
            return;
        }

        Rigidbody.WakeUp();
        OnPressed?.Invoke();
        Shadow.SetActive(false);

        Target.position = new Vector2(Random.Range(-2.21f, 2.21f), Random.Range(-0.5f, 1.72f));
        Vector2 direction = Target.position - transform.position;

        Rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        Invoke(nameof(ResetMe), 2.5f);
    }

    private void Update()
    {
        float distanceToGoal = Mathf.Abs(Center.position.y - transform.position.y);
        if(distanceToGoal <= 1 && !EndTravel)
        {
            EndTravel = true;
            OnTravelled?.Invoke();
        }

        transform.localScale = Vector2.Lerp(TargetScale, InitScale, distanceToGoal / totalDistance);
    }

    public static void Sleep()
    {
        Velocity = Rigidbody.velocity;
        Rigidbody.Sleep();
    }

    public static void WakeUp()
    {
        Rigidbody.WakeUp();
        Rigidbody.velocity = Velocity;

        UpdateRender();
    }

    private void ResetMe()
    {
        EndTravel = false;
        Shadow.SetActive(true);

        Rigidbody.velocity = Vector2.zero;
        Rigidbody.angularVelocity = 0;

        transform.position = new Vector2(0, -2.699363f);
        Rigidbody.Sleep();
    }

    private static void UpdateRender()
    {
        SpriteRenderer.sprite = Resources.Load<Sprite>($"Balls/{PlayerPrefs.GetInt(Balls.BallKey)}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("over zone"))
        {
            return;
        }

        UIManager.OpenWindow(Window.GameOver);
        BPGame.GameOver();
    }
}
