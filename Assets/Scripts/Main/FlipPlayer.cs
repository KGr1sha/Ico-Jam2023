using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    public void SetLookDirection(string direction)
    {
        if (direction == "right")
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
        }
        else if (direction == "left")
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, 0);
        }
    }
}
