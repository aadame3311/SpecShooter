using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Text title;
    private bool fade_in;
    private float blink_speed;

    private void Start()
    {
        fade_in = false;
        blink_speed = 2f;
    }

    private void Update()
    {
        // flag switches that determine when to fade in and out.
        if (title.color.r <= 0.4 && title.color.g <= 0.4 && title.color.b <= 0.4)
            fade_in = true;
        if (title.color.r >= 0.7 && title.color.g >= 0.7 && title.color.b >= 0.7)
            fade_in = false;

        // fade the title text in and out over a period of time (time/blinkspeed).
        if (!fade_in)
        {
            title.color = new Color(title.color.r - Time.deltaTime / blink_speed, title.color.g - Time.deltaTime / blink_speed, title.color.b - Time.deltaTime / blink_speed, title.color.a);
        }
        if (fade_in)
        {
            title.color = new Color(title.color.r + Time.deltaTime / blink_speed, title.color.g + Time.deltaTime / blink_speed, title.color.b + Time.deltaTime / blink_speed, title.color.a);
        }
        
    }

    public void PlayButtonPressed(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    public void Restart(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
