using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Destroyer());
    }

    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
