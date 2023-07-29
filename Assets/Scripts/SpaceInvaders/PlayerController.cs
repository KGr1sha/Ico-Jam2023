using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _horizontalInput;

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(new Vector3(_horizontalInput, 0, 0) * Time.deltaTime * _speed);
    }
}
