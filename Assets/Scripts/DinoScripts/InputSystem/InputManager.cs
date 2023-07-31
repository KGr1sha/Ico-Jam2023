using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [Header("Desktop.")]
    [SerializeField] private GameObject tooltips;

    [Header("Settings.")]
    [SerializeField] private bool isGameStarted;

    [SerializeField] private UnityEvent gameStart;
    [SerializeField] private UnityEvent jumpButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonUp;

    private void Awake()
    {
        this.tooltips.SetActive(true);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnPlayButtonDown();
            OnJumpButtonDown();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) onCrouchButtonDown();
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) onCrouchButtonUp();
    }
    public void OnPlayButtonDown()
    {
        if (this.isGameStarted == false)
        {
            this.isGameStarted = true;
            this.gameStart?.Invoke();
            this.tooltips.SetActive(false);
        }
    }

    public void OnJumpButtonDown()
    {
        this.jumpButtonDown?.Invoke();
        Debug.Log(message: "Jump!");

    }

    public void onCrouchButtonDown()
    {
        this.crouchRunButtonDown?.Invoke();
        Debug.Log(message: "Crouch button down!");
    }

    public void onCrouchButtonUp()
    {
        this.crouchRunButtonUp?.Invoke();
        Debug.Log(message: "Crouch button up!");
    }
}
