using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Screen_fader : MonoBehaviour
{
    [SerializeField] float fade_speed;
    [SerializeField] GameObject bg;
    [SerializeField] TextMeshProUGUI[] texts;

    private Image background;

    private IEnumerator Start()
    {
        background = bg.GetComponent<Image>();

        Color color_bg = background.color;
        Color color_text = texts[0].color;

        while(color_bg.a < 1f)
        {
            color_bg.a += fade_speed * Time.deltaTime;
            color_text.a += fade_speed * Time.deltaTime;
            background.color = color_bg;
            for(int i = 0; i < texts.Length; i++)
            {
                texts[i].color = color_text;
            }
            yield return null;
        }
    }
}
