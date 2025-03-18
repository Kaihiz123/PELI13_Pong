using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float ballStartSpeed = 5f;
    Rigidbody2D rb;

    public TMPro.TextMeshProUGUI leftText;
    public TMPro.TextMeshProUGUI rightText;

    int leftPoints = 0;
    int rightPoints = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LaunchBall();
        leftText.text = "" + leftPoints;
        rightText.text = "" + rightPoints;
    }

    void LaunchBall()
    {
        transform.position = Vector3.zero;
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.linearVelocity = direction.normalized * ballStartSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Platform"))
        {
            rb.linearVelocity *= 1.1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftTriggerArea"))
        {
            rightPoints++;
            rightText.text = "" + rightPoints;
            LaunchBall();
        }
        if (collision.gameObject.CompareTag("RightTriggerArea"))
        {
            leftPoints++;
            leftText.text = "" + leftPoints;
            LaunchBall();
        }
    }

}
