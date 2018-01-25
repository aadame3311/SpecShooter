using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pause;
    public GameObject game_over;

    private GameObject player;


    // for UI Pause button. 
    private bool is_paused;

	// Use this for initialization
	void Start () {
        is_paused = false;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (gameController.isPaused && player != null || is_paused)
            pause.SetActive(true);
        else if (!gameController.isPaused && player == null)
            game_over.SetActive(true);
        else
        {
            pause.SetActive(false);
            game_over.SetActive(false);
        }
            
	}

    public void IsPaused()
    {
        is_paused = !is_paused;
        gameController.isPaused = !gameController.isPaused;
    }
}
