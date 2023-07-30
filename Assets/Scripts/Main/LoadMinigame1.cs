using UnityEngine;

public class LoadMinigame1 : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _levelLoader.LoadScene("Minigame1");
        }
    }
}
