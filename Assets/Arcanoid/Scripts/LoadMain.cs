using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain : MonoBehaviour
{
    public CollectablesStatus data;

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
