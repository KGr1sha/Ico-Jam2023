using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;

    private void Start()
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
