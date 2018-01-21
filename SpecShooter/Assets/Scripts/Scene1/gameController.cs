using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {



    // var to check if game is paused
    public static bool isPaused;

    // import player
    private GameObject player;
    private Movement mov;

	// Use this for initialization
	void Start () {
        isPaused = false;

        player = GameObject.FindGameObjectWithTag("Player");
        mov = player.GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {

        // checks if game is paused
        if (Input.GetButtonDown("Pause") && !Movement.isDead)
        {
            isPaused = !isPaused;
        }
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        // checks if player has died.
        if (mov == null)
        {
            Time.timeScale = 0;
        }
            
	}
}
