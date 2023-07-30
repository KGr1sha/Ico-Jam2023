using System.Collections;
using UnityEngine;

public class AllienBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeSpan = 10f;

    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = transform.right * _speed;
        StartCoroutine(DeleteTimer());
    }

    private IEnumerator DeleteTimer()
    {
        yield return new WaitForSeconds(_lifeSpan);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damagableObject = collision.GetComponent<IDamagable>();
        if (damagableObject != null && collision.gameObject.CompareTag("Enemy"))
        {
            damagableObject.TakeDamage(1);
        }
        Destroy(this.gameObject);
    }
}
