using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerLife.OnPlayerDie += Lose;
        Score.OnGoalScore += Win;
    }

    private void OnDisable()
    {
        PlayerLife.OnPlayerDie -= Lose;
        Score.OnGoalScore -= Win;
    }

    private void Win()
    {
        Debug.Log("CHICKEN DINNER");
    }

    private void Lose()
    {
        Debug.Log("BIG BLACK");
    }
}
