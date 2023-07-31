using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipTrigger : MonoBehaviour
{
    [SerializeField] GameObject putFragmentsIn;
    [SerializeField] public CollectablesStatus data;
    [SerializeField] private GameObject winScreen;

    private TMP_Text putFargmetsText;

    private void Start()
    {
        putFargmetsText = putFragmentsIn.GetComponent<TMP_Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Enter");
            putFragmentsIn.SetActive(true);
            if (data.Fragment1Collected && data.Fragment2Collected && data.Fragment3Collected)
            {
                putFargmetsText.text = "Press \"F\" to start the spaceship!";
            }
            else
            {
                putFargmetsText.text = "You need to find all of the fragments";
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Start") && data.Fragment1Collected && data.Fragment2Collected && data.Fragment3Collected)
            {
                winScreen.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            putFragmentsIn.SetActive(false);
        }

    }

}
