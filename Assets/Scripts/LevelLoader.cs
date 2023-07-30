using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 1f;
    [SerializeField] private GameObject _countdownObject;
    [SerializeField] private float _countdownTime;

    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _textMeshPro = _countdownObject.GetComponent<TextMeshProUGUI>();
    }

    public void LoadScene(string name)
    {
        _countdownObject.SetActive(true);
        if (SceneManager.GetActiveScene().name == "Main")
        {
            StartCoroutine(CountDown());
        }
        StartCoroutine(LoadMinigame(name));
    }

    private IEnumerator LoadMinigame(string name)
    {
        yield return new WaitForSeconds(_countdownTime);
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(name);
    }

    private IEnumerator CountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            _textMeshPro.text = i.ToString();
            yield return new WaitForSeconds(_countdownTime / 3);
        }
    }
}
