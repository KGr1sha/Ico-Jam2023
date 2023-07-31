using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int addScorePerIteration;
    [SerializeField] private float iterationDelta;
    [SerializeField] private float minIterationDelta;
    [SerializeField] private float maxIterationDelta;
    [SerializeField] private float lessDeltaPerSecond;
    [SerializeField] private float nonLessDeltaTime;
    [Space]
    [SerializeField] private int scoreCount;
    [SerializeField] private int neededScoreCount;

    public static event Action<int> OnScoreChanged;

    private IEnumerator ScoreCounter()
    {
        while(true)
        {
            this.scoreCount += this.addScorePerIteration;
            OnScoreChanged?.Invoke(scoreCount);

            if (this.scoreCount == neededScoreCount)
            {
            }

            yield return new WaitForSeconds(this.iterationDelta);
        }   
    }

    private IEnumerator IterationDeltaCounter()
    {
        yield return new WaitForSeconds(this.nonLessDeltaTime);
        while (true)
        {
            this.iterationDelta -= this.lessDeltaPerSecond / 10;
            this.iterationDelta = Mathf.Clamp(iterationDelta, minIterationDelta, maxIterationDelta);

            yield return new WaitForSeconds(0.1f);
        }


    }
    public void OnGameStart()
    {
        StartCoroutine(ScoreCounter());
        StartCoroutine(IterationDeltaCounter());
    }

    public void OnPlayerDead()
    {
        StopAllCoroutines();
    }
}
