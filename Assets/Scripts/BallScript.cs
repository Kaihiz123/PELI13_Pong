using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float ballStartSpeed = 5f;
    Rigidbody2D rb;

    public TMPro.TextMeshProUGUI leftText;
    public TMPro.TextMeshProUGUI rightText;

    int leftPoints = 0;
    int rightPoints = 0;

    Vector2 direction;
    float ballSpeed;

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
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.linearVelocity = direction.normalized * ballStartSpeed;
        ballSpeed = rb.linearVelocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Platform"))
        {
            //rb.linearVelocity *= 1.1f;
            direction = Vector2.Reflect(direction, collision.GetContact(0).normal);
            ballSpeed *= 1.1f;
            rb.linearVelocity = direction.normalized * ballSpeed;
        }
    }

    private void Update()
    {
        if(transform.position.x < -9.5f)
        {
            rightPoints++;
            rightText.text = "" + rightPoints;
            CheckPoints();
            LaunchBall();
        }

        if(transform.position.x > 9.5f)
        {
            leftPoints++;
            leftText.text = "" + leftPoints;
            CheckPoints();
            LaunchBall();
        }
    }

    int maxPoints = 3;

    private void CheckPoints()
    {
        if(rightPoints > maxPoints)
        {
            Debug.Log("Left player wins!");
            GameManager.Instance.LeftPlayerGetsAPoint();
            GameManager.Instance.ChangeScene();
        }
        else if(leftPoints > maxPoints)
        {
            Debug.Log("Right player wins!");
            GameManager.Instance.RightPlayerGetsAPoint();
            GameManager.Instance.ChangeScene();
        }
    }
}
