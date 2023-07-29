using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _scorePerEnemy;

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
    }

    private void UpdateScore()
    {
        _scoreText.text = _score.ToString();
    }
}
