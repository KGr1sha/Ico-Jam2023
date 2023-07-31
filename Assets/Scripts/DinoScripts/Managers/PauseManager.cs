using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject winScreen;
    public void DeathPause()
    {
        this.deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void WinPause()
    {
        this.winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue() => Time.timeScale = 1;
}
