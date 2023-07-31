using UnityEngine;

public class PlayWinMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _mainMusic;

    void Start()
    {
        GetComponent<AudioSource>().Play();
        _mainMusic.Stop();

    }

}
