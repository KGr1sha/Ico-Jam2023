using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Screen_fader : MonoBehaviour
{
    [SerializeField] float fade_speed;

    [SerializeField] GameObject bg;
    [SerializeField] GameObject res;
    [SerializeField] GameObject cont;

    private Image background;
    private TMP_Text result;
    private TMP_Text continue_t;

    private IEnumerator Start()
    {
        background = bg.GetComponent<Image>();
        result = res.GetComponent<TMP_Text>();
        continue_t = cont.GetComponent<TMP_Text>();

        Color color_bg = background.color;
        Color color_res = result.color;
        Color color_cont = continue_t.color;

        while(color_bg.a < 1f)
        {
            color_bg.a += fade_speed * Time.deltaTime;
            color_res.a += fade_speed * Time.deltaTime;
            color_cont.a += fade_speed * Time.deltaTime;
            background.color = color_bg;
            result.color = color_res;
            continue_t.color = color_cont;
            yield return null;
        }
    }
}
