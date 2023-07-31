using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private CollectablesStatus _data;
    [SerializeField] private MapMover _mapScript;

    public void DeathPause()
    {
        this.deathScreen.SetActive(true);
        _mapScript.isPlay = false;
        StartCoroutine(ReturnToMain());
    }

    public void WinPause()
    {
        this.winScreen.SetActive(true);
        _mapScript.isPlay = false;
        _data.Fragment3Collected = true;
        StartCoroutine(ReturnToMain());
    }

    private IEnumerator ReturnToMain()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Main");
    }

    public void Continue() => Time.timeScale = 1;
}
