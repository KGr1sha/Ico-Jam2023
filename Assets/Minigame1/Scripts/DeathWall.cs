using UnityEngine;

public class DeathWall : MonoBehaviour
{   
    PlayerController1 controller;
    GameSession gameSession;

    private void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController1>();
        gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            controller.ResetBall();
            gameSession.ReduceLives();
        }
    }
}
