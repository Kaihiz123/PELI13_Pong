using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    [SerializeField] private float moveSpeed = 2f;

    float clampY = 3.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        
    }

    private void Update()
    {
        float moveDirection = Input.GetAxisRaw("Vertical");
        float newPositionY = transform.position.y + moveDirection * moveSpeed * Time.deltaTime;

        newPositionY = Mathf.Clamp(newPositionY, -clampY, clampY);

        transform.position = new Vector2(transform.position.x, newPositionY);
    }
}
