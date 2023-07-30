using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth;

    private Animator _animator;
    private int _health;

    protected virtual void Start()
    {
        _health = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();
        }
        else
            DamageAnimation();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void DamageAnimation()
    {
        _animator.SetTrigger("Damaged");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<IDamagable>().TakeDamage(1);
        }
    }
}
