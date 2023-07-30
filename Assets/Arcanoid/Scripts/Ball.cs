using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] float speed = 15f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    public void Launch(Vector2 direction)
    {
        transform.parent = null;
        rb.simulated = true;
        rb.velocity = direction.normalized * speed;
    }

    public void Catch(Transform parent)
    {
        transform.parent = parent;
        rb.simulated = false;
        rb.velocity = Vector2.zero;
    }
}
