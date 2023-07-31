using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMain : MonoBehaviour
{
    public CollectablesStatus data;
    private GameObject player;

    [SerializeField] GameObject miniGame1;
    [SerializeField] GameObject miniGame2;
    [SerializeField] GameObject miniGame3;

    private void Start()
    {   
        if (!data.Fragment1Collected && !data.Fragment2Collected && !data.Fragment3Collected)
        {
            data.PlayerPositionWhenStartMinigame = new Vector3 (0, 0, 0);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = data.PlayerPositionWhenStartMinigame;
        if (data.Fragment1Collected)
        {
            Destroy(miniGame1);
        }  
        if (data.Fragment2Collected)
        {
            Destroy(miniGame2);
        }
        if(data.Fragment3Collected)
        {
            Destroy(miniGame3);
        }
    }
}
