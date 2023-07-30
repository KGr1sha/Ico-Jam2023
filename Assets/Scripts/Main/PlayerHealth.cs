using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
        Debug.Log("GET DAMAGED");
        if (_health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("YOU DIED");
    }
}
