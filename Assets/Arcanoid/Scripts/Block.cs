using UnityEngine;

public class Block : MonoBehaviour
{
    int health;
    SpriteRenderer sp;
    Color[] colors = { Color.yellow , Color.blue , Color.red };
    [SerializeField] Sprite[] sprites = new Sprite[3];

    private void Start()
    {   
        sp = GetComponent<SpriteRenderer>();

        health = Random.Range(1, 4);
        sp.sprite = sprites[health - 1];
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        sp.sprite = sprites[health - 1];
    }
}
