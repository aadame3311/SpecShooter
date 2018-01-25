using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public static int amount_killed;
    public static float difficulty;

    public int spawn_limit;
    public static int curr_spawned;
    public static bool can_spawn;


	void Start () {
        // variable initializations

        //difficulty related.
        amount_killed = 0;
        difficulty = 1.0f;

        //spawn amount controllers.
        spawn_limit = 5;
        curr_spawned = 0;

        //permissions.
        can_spawn = true;
	}
	
	// Update is called once per frame.
	void Update () {

        // base difficulty on player score.
        if (amount_killed >= 60)
            difficulty = 4.5f;
        else if (amount_killed >= 40)
            difficulty = 4.0f;
        else if (amount_killed >= 25)
            difficulty = 3.0f;
        else if (amount_killed >= 10)
            difficulty = 2.0f;


		if (curr_spawned >= spawn_limit)
        {
            can_spawn = false;
        }
        if (curr_spawned < spawn_limit)
        {
            can_spawn = true;
        }
	}
}
