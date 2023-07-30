using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMover : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Minimum moving speed.")]
    [SerializeField] private float minSpeed;

    [Tooltip("Maximum moving speed.")]
    [SerializeField] private float maxSpeed;

    [Tooltip("Current moving speed.")]
    [SerializeField] private float speed;

    [Tooltip("Boost moving speed per second.")]
    [SerializeField] private float boostSpeedPerSecond;

    [SerializeField] private float nonBoostSpeedTime;

    [SerializeField] private bool isPlay;

    private void Update()
    {
        if (this.isPlay)
        {
            Vector3 position = transform.position;
            position = Vector3.Lerp(a: position, b: position + Vector3.left, t: Time.deltaTime * this.speed);
            transform.position = position;
        }
    }

    private IEnumerator SpeedCounter()
    {
        yield return new WaitForSeconds(this.nonBoostSpeedTime);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            this.speed *= boostSpeedPerSecond / 10;

            this.speed = Mathf.Clamp(this.speed, this.minSpeed, this.maxSpeed);

        }
    }

    public void onGameStart()
    {
        StartCoroutine(routine: SpeedCounter());
    }

    public void OnPause() => this.isPlay = false;

    public void OnContinue() => this.isPlay = true;
}
