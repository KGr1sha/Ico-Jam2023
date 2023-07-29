using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }        
    }

    private void ShootBullet()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
    }
}
