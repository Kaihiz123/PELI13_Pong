using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float ballStartSpeed = 5f;
    Rigidbody2D rb;
    public float speedMagnitude;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LaunchBall();
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.linearVelocity = direction.normalized * ballStartSpeed;
    }

    private void FixedUpdate()
    {
        speedMagnitude = rb.linearVelocity.magnitude;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Platform"))
        {
            rb.linearVelocity *= 1.1f;
            
            /*
            Vector2 velocity = rb.linearVelocity;
            Vector2 normal = collision.GetContact(0).normal;

            rb.linearVelocity = Vector2.Reflect(velocity, normal);
            */
        }
    }
    
}
