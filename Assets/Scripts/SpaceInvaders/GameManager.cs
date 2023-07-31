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

    public bool result = false;

    public CollectablesStatus data;

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
        result = true;
        resultText.text = "You have received the second item!";
        data.Fragment2Collected = true;
        gameOver.SetActive(true);
    }
    private void Lose()
    {
        if (result == false)
        {
            resultText.text = "You lose";
            gameOver.SetActive(true);
        }
    }
}
