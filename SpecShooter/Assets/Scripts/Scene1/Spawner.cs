using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public SpawnerController sc;
    public GameObject s;

    public GameObject asteroid;
    public GameObject enemy1;
    private float interval = 1f;
    float val = 0f;
	
	// Update is called once per frame
	void Update () {

        // decrease interval by a second at a time. 
        interval -= Time.deltaTime;
        if (interval <= 0)
        {
            val = Random.value * 25;

            // only a certain amount of enemies are allowed to be spawned.
            if (sc.can_spawn)
            {
                if ((int)val == 3)
                {
                    Instantiate(asteroid, transform.position, transform.rotation);
                    SpawnerController.curr_spawned++;
                }
                else if ((int)val == 10 || (int)val == 19)
                {
                    Instantiate(enemy1, transform.position, transform.rotation);
                    SpawnerController.curr_spawned++;
                }
            }
              
            interval = 5f;
        }
	}
}
