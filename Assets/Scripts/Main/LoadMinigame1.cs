using UnityEngine;

public class LoadMinigame1 : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private string _sceneToLoad;
    [SerializeField] private GameObject player;

    public CollectablesStatus data;

    private bool _activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _activated == false)
        {
            _activated = true;
            data.PlayerPositionWhenStartMinigame = player.transform.position;
            _levelLoader.LoadScene(_sceneToLoad);
        }
    }
}
