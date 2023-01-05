using System;
using UnityEngine;

public class BootPlayer : MonoBehaviour
{
    private Camera _camera;
    private Vector2 target;

    private Transform Point { get; set; }
    public static Ball BallRef { get; set; }

    private static SpriteRenderer SpriteRenderer { get; set; }


    private const float speed = 6.5f;

    public static Action OnCollided { get; set; } = delegate { };

    private void OnEnable()
    {
        UpdateRender();
    }

    private void Awake()
    {
        _camera = Camera.main;
        target = transform.position;

        Point = transform.GetChild(0);
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDrag()
    {
        target = new Vector2(_camera.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
    }

    private void Update()
    {
        UpdatePosition();
        UpdateRotatiton();
    }

    private void UpdatePosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void UpdateRotatiton()
    {
        float disatnce = Vector2.Distance(Point.position, BallRef.transform.position);
        if (disatnce < 1)
        {
            transform.localEulerAngles = new Vector3(0, 0, -18.86f);
        }
        else
        {
            transform.localEulerAngles = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        Instantiate(Resources.Load<GameObject>("hit"), collision.GetContact(0).point, Quaternion.identity, GameObject.Find("Environment").transform);
        OnCollided?.Invoke();
    }

    public static void UpdateRender()
    {
        SpriteRenderer.sprite = Resources.Load<Sprite>($"Boots/{PlayerPrefs.GetInt(Boots.BootsKey)}");
    }
}
