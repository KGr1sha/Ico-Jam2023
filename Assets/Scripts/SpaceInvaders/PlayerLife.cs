using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameObject _deathExplosion;

    public static event Action OnPlayerDie;

    public void Die()
    {
        Instantiate(_deathExplosion, transform.position, Quaternion.identity);
        OnPlayerDie?.Invoke();
        Destroy(this.gameObject);
    }
}
