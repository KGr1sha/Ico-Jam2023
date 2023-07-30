using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y > 20 || transform.position.y < -20)
        {
            Destroy(gameObject);
        }       
    }
}
