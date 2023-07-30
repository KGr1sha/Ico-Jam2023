using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] TMP_Text livesText;
    [SerializeField] int lives = 3;

    bool result;

    private void Start()
    {
        livesText.text = lives.ToString();
    }

    private void Update()
    {
        var blocks = GameObject.FindGameObjectsWithTag("Block");
        if(blocks.Length == 0 )
        {
            bool result = true;
        }
    }

    public void ReduceLives()
    {
        lives--;
        if (lives > 0)
        {
            livesText.text = lives.ToString();
        } else
        {
            livesText.text = "Game Over!!!";
            bool result = false;
        }
    }
}
