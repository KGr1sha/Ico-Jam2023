using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject resultObj;
    [SerializeField] GameObject gameOver;
    [SerializeField] private TextMeshProUGUI resultText;

    public bool result;

    public CollectablesStatus data;

    private void Start()
    {
       
    }
    private void OnEnable()
    {
        PlayerLife.OnPlayerDie += Lose;
        Score.OnGoalScore += Win;
    }

    private void OnDisable()
    {
        Score.OnGoalScore -= Win;
        PlayerLife.OnPlayerDie -= Lose;
    }

    private void Win()
    {
        Debug.Log("CHICKEN DINNER");
        result = true;
        resultText.text = "You have received the second item!";
        data.Fragment2Collected = true;
        gameOver.SetActive(true);
    }
    private void Lose()
    {
        Debug.Log("BIG BLACK");
        result = false;
        resultText.text = "You lose";
        gameOver.SetActive(true);
    }
}
