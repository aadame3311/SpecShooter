using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pause;
    public GameObject game_over;

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (gameController.isPaused && player != null)
            pause.SetActive(true);
        else if (!gameController.isPaused && player == null)
            game_over.SetActive(true);
        else
        {
            pause.SetActive(false);
            game_over.SetActive(false);
        }
            
	}
}
