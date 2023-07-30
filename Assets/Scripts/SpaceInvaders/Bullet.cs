using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyShip>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
