using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        objectWidth = sprite.bounds.size.x / 2;
    }

    private void LateUpdate()
    {
        Vector3 viewpos = transform.position;
        viewpos.x = Mathf.Clamp(viewpos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);

        transform.position = viewpos;
    }
}

