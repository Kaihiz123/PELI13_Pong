using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        
    }
}
