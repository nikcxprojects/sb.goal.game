using System;
using UnityEngine;

public class BallPlayer : MonoBehaviour
{
    private Camera Camera { get; set; }
    private static Vector2 Velocity { get; set; }
    private static Rigidbody2D Rigidbody2D { get; set; }
    private static SpriteRenderer SpriteRenderer { get; set; }

    private const float dragForce = 45.0f;

    public static Action OnCollided { get; set; }
    public static Action OnLived { get; set; }

    private float nextTime;
    private const float scoreRate = 1;

    private Vector2 Direction { get; set; }

    private void Awake()
    {
        Camera = Camera.main;

        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Settings.IsOpened || AppManager.IsEquip || AppManager.IsPause)
        {
            return;
        }

        if (Time.time > nextTime)
        {
            OnLived?.Invoke();
            nextTime = Time.time + scoreRate;
        }
    }

    private void FixedUpdate()
    {
        if (Direction.sqrMagnitude > .1f)
        {
            Rigidbody2D.AddForce(Direction.normalized * dragForce, ForceMode2D.Force);
        }
    }

    private void OnEnable()
    {
        UpdateRender();
    }

    private void OnMouseDrag()
    {
        if (Settings.IsOpened || AppManager.IsEquip || AppManager.IsPause)
        {
            return;
        }

        Direction = Camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    public static void Sleep()
    {
        Velocity = Rigidbody2D.velocity;
        Rigidbody2D.Sleep();
    }

    public static void WakeUp()
    {
        Rigidbody2D.WakeUp();
        Rigidbody2D.velocity = Velocity;

        UpdateRender();
    }

    private static void UpdateRender()
    {
        SpriteRenderer.sprite = Resources.Load<Sprite>($"Balls/{PlayerPrefs.GetInt(Balls.BallKey)}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("over zone"))
        {
            OnCollided?.Invoke();
            return;
        }

        UIManager.OpenWindow(Window.GameOver);
        SMGame.GameOver();
    }
}
