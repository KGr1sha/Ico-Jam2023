using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private CollectablesStatus _data;

    public void DeathPause()
    {
        this.deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void WinPause()
    {
        this.winScreen.SetActive(true);
        Time.timeScale = 0;
        _data.Fragment3Collected = true;
        LoadMain();
    }

    private void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void Continue() => Time.timeScale = 1;
}
