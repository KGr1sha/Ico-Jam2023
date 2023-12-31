using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootCD;
    [SerializeField] private AudioSource _shotSound;

    private bool _canShoot = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _canShoot)
        {
            Shoot();
        }    
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        _canShoot = false;
        _shotSound.Play();
        StartCoroutine(ShootCD());
    }

    private IEnumerator ShootCD()
    {
        yield return new WaitForSeconds(_shootCD);
        _canShoot = true;
    }
}
