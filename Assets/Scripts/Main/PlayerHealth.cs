using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
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
    }
    public void Die()
    {
        Debug.Log("YOU DIED");
    }
}
