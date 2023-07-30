using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    private TMP_Text resultText;
    public bool result;

    public CollectablesStatus data;

    private void Start()
    {
        resultText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (result)
        {
            resultText.text = "You have received the first item!";
            data.Fragment1Collected = true;
        } else
        {
            resultText.text = "You lose";
        }
    }
}
