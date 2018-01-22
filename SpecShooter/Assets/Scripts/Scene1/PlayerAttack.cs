using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {


    // array of weapons available.
    public GameObject[] weapon = new GameObject[2];
    public static int weapon_to_use;


    private void Start()
    {
        weapon_to_use = 0;
    }


    // Update is called once per frame
    void Update () {
        float input = Input.GetAxisRaw("Fire1");

        // if (input > 0)
        if (Input.GetKeyDown("space") && (!Movement.isDead && !gameController.isPaused))
        {
            if (weapon_to_use == 0 && gameObject.tag == "turret")
            {
                Debug.Log("Regular Bullets :(");

                Instantiate(weapon[weapon_to_use], transform.position, transform.rotation);
            }
            else if (weapon_to_use == 1 && gameObject.tag == "sniperTurret")
            {
                Debug.Log("Sniper Activated!");

                Instantiate(weapon[weapon_to_use], transform.position, transform.rotation);
            }
        }
	}
}
