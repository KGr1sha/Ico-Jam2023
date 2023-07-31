using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPresenter : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
   public void OnPlayerDead()
    {
        deathScreen.SetActive(true);
    }
}
