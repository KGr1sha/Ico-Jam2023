using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth;

    private int _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
