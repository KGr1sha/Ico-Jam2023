using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _scorePerEnemy;
    [SerializeField] private int _goalScore;

    public static event Action OnGoalScore;

    private int _score;

    private void OnEnable()
    {
        EnemyShip.OnEnemyDie += AddScore;
    }

    private void OnDisable()
    {
        EnemyShip.OnEnemyDie -= AddScore;
    }

    private void AddScore()
    {
        _score += _scorePerEnemy;
        UpdateScore();
        if (_score == _goalScore)
        {
            OnGoalScore?.Invoke();
        }
    }

    private void UpdateScore()
    {
        _scoreText.text = _score.ToString();
    }
}
