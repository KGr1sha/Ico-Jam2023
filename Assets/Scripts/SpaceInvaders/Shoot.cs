using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shotCD;

    private bool _canShoot = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _canShoot)
        {
            ShootBullet();
        }        
    }

    private void ShootBullet()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        _canShoot = false;
        StartCoroutine(ShootingCD());
    }

    private IEnumerator ShootingCD()
    {
        yield return new WaitForSeconds(_shotCD);
        _canShoot = true;
    }
}
