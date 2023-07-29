using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] Vector2 launchDirection = new Vector2 (1, 4);

    [SerializeField] GameObject ballPrefab;
    
    Rigidbody2D rb;
    Vector2 ballOffset;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ball ball = GetComponentInChildren<Ball>();
        ballOffset = ball.transform.position - transform.position;
    }
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);  
        
        if(transform.childCount > 0 && Input.GetButtonDown("Jump"))
        {
            Ball ball = GetComponentInChildren<Ball>();
            ball.Launch(launchDirection);
        }
    }
    public void ResetBall()
    {
        Ball ball = Instantiate(ballPrefab, transform).GetComponent<Ball>();
    }

}
