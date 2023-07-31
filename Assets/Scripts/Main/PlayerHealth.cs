using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int animationTime;
    [SerializeField] private GameObject DeathScreen;

    private DetailsResultText detailsResultText;

    private int _health;

    private void Start()
    {
        _health = _maxHealth;
        detailsResultText = DeathScreen.GetComponent<DetailsResultText>();
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
     private void Die()
    {
        Debug.Log("YOU DIED");
        //play animation
        //yield return new WaitForSeconds(animationTime);
        detailsResultText.ResultChanger();
        DeathScreen.SetActive(true);
    }
}
