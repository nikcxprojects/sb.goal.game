using UnityEngine;

public class BallPlayer : MonoBehaviour
{
    private const float normalGravity = 1;
    private const float fallGravity = 3.0f;

    private Rigidbody2D Rigidbody { get; set; }

    [SerializeField] float force;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Rigidbody.gravityScale = Rigidbody.velocity.y < 0 ? fallGravity : normalGravity;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !Settings.IsOpened && !AppManager.IsPause)
        {
            bool IsTrueClick = Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 2.0f;
            if(IsTrueClick)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        Rigidbody.angularVelocity = 0;
        Rigidbody.AddTorque(10);
    }
}
