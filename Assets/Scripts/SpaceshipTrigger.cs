using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpaceshipTrigger : MonoBehaviour
{
    [SerializeField] GameObject putFragmentsIn;
    [SerializeField] public CollectablesStatus data;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject ship;
    [SerializeField] private GameObject partickles;
    [SerializeField] private GameObject winParticles;

    [SerializeField] private UnityEvent OnShipRepare;
    [SerializeField] Sprite shipRepaired;

    private TMP_Text putFargmetsText;
    private SpriteRenderer shipSprite;

    private bool isShipRepaired = false;

    private void Start()
    {
        putFargmetsText = putFragmentsIn.GetComponent<TMP_Text>();
        shipSprite = ship.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            if (data.Fragment1Collected && data.Fragment2Collected && data.Fragment3Collected && !isShipRepaired)
            {
                putFargmetsText.text = "Press \"F\" to repair your spaceship";
            }
            else if (!isShipRepaired)
            {
                putFargmetsText.text = "You need to find all of the fragments";
            }
            putFragmentsIn.SetActive(true);
        }

    }
    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Start") && data.Fragment1Collected && data.Fragment2Collected && data.Fragment3Collected && !isShipRepaired)
            {
                putFargmetsText.text = "Congratulations!!!";
                partickles.SetActive(false);
                OnShipRepare?.Invoke();
                yield return new WaitForSeconds(1.5f);
                shipSprite.sprite = shipRepaired;
                winParticles.SetActive(true);
                yield return new WaitForSeconds(7);
                winParticles.SetActive(false);
                isShipRepaired = true;
            }
        }
    }

    private void Update()
    {
        if (isShipRepaired)
        {
            putFargmetsText.text = "Press \"F\" to start the spaceship!";
            if (Input.GetButtonDown("Start"))
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
