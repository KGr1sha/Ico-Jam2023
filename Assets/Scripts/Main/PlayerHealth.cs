using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int animationTime;
    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private AudioSource _deathSound;

    private DetailsResultText detailsResultText;

    private int _health;
    private bool _isDead;

    private void Start()
    {
        _health = _maxHealth;
        detailsResultText = DeathScreen.GetComponent<DetailsResultText>();
        _isDead = false;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0 && _isDead == false)
        {
            Die();
        }
    }
     private void Die()
    {
        _isDead = true;
        _deathSound.Play();
        detailsResultText.ResultChanger();
        DeathScreen.SetActive(true);
    }
}
