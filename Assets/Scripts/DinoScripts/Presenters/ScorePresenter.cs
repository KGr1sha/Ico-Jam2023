using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScorePresenter : MonoBehaviour
{
    [Header("Components.")]
    [SerializeField] private Text scoreText;

    private void Awake()
    {
        if (this.scoreText == null) this.scoreText = GetComponent<Text>();
        ScoreManager.OnScoreChanged += UpdateText;
    }

    private void UpdateText(int val)
    {
        scoreText.text = val.ToString();
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateText;
    }
}
