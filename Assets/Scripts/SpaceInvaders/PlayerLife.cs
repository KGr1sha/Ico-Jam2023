using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameObject _deathExplosion;

    public void Die()
    {
        Instantiate(_deathExplosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
