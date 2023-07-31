using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{
    [SerializeField] CollectablesStatus data;
    public void ResetData()
    {
        data.Fragment1Collected = false;
        data.Fragment2Collected = false;
        data.Fragment3Collected = false;
        data.PlayerPositionWhenStartMinigame = Vector3.zero;
    }

    public void PlayGame ()
        {   
            
            SceneManager.LoadScene("Main");
        }
}
