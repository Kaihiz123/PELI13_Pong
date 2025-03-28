using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    [Range(0.1f, 2.0f)]
    [SerializeField] float scrollSpeed;

    Renderer rend;
    float offset;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
    }
}
