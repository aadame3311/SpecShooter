using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIndicator : MonoBehaviour {

    public Text sniper_text;
    public Text MG_text;
    public Canvas c;

    public static bool once;

    float interval;
    private bool fadeout_done;
    

	// Use this for initialization
	void Start () {
        fadeout_done = false;
        interval = 1;

        once = false;
	}


    // Update is called once per frame
    void LateUpdate () {
        if (PlayerAttack.weapon_to_use == 1 && sniper_text != null && !once)
        {
            once = true;

            sniper_text.color = new Color(sniper_text.color.r, sniper_text.color.g, sniper_text.color.b, 1);
            StartCoroutine(Fade(5.0f, sniper_text));
            
        }
        else if (PlayerAttack.weapon_to_use == 0 && MG_text != null && !once)
        {
            once = true;

            MG_text.color = new Color(MG_text.color.r, MG_text.color.g, MG_text.color.b, 1);
            StartCoroutine(Fade(5.0f, MG_text));

        }

    }

    private void SetDone(bool a)
    {
        fadeout_done = a;
    } 

    IEnumerator Fade(float t, Text i)
    {
        Debug.Log("a");
        i.color = new Color(i.color.r, i.color.g, i.color.b, 250);

        for (float f = 1f; f > -1f; f -= 0.05f/t)
        { 

            Color c = i.color;
            c.a = f;
            i.color = c;

            if (f < 0) SetDone(true);
            yield return null;
        }
    }
}

