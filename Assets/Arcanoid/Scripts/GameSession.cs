using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] TMP_Text livesText;

    [SerializeField] int lives = 3;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject resultObj;

    private Result resultScript;

    private void Start()
    {   
        resultScript = resultObj.GetComponent<Result>();
        livesText.text = lives.ToString();
    }

    private void Update()
    {
        var blocks = GameObject.FindGameObjectsWithTag("Block");
        if(blocks.Length == 0 )
        {
            resultScript.result = true;
            gameOver.SetActive(true);
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
            resultScript.result = false;
            gameOver.SetActive(true);
        }
    }
}
