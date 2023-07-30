using UnityEngine;

public class CustomBouncy : MonoBehaviour
{
    BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {   
        if (other.gameObject.tag == "Ball")
        {
            float relativePosition = (other.transform.position.x - transform.position.x) / bc.bounds.size.x;
            other.rigidbody.velocity = new Vector2(relativePosition, 1).normalized * other.rigidbody.velocity.magnitude;
        }
    }
}
