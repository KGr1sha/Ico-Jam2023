using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _movespeed;
    [SerializeField] private float _stepOffset;

    private void Update()
    {
        transform.Translate(Vector2.right * _movespeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenBounds"))
        {
            _movespeed *= -1;
            transform.position += new Vector3(0, -_stepOffset, 0);
        }
    }
}
