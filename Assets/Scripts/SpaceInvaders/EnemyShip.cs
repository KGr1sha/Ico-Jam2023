using System;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private int _startingHealth;
    [SerializeField] private GameObject _deathExplosion;

    public static event Action OnEnemyDie;

    private int _health;

    private void Start()
    {
        _health = _startingHealth;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(_deathExplosion, transform.position, Quaternion.identity);
        OnEnemyDie?.Invoke();
        Destroy(this.gameObject);
    }
}
