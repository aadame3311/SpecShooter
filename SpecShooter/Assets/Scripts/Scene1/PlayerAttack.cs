using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {


    // array of weapons available.
    public GameObject[] weapon = new GameObject[2];
    public static int weapon_to_use;
    public static int curr_weapon;
    public static bool new_weapon;

    //UI Controls
    private bool fire_weapon;
    private bool fire_once;

    private void Start()
    {
        new_weapon = false;
        weapon_to_use = 0;
        curr_weapon = weapon_to_use;
    }


    // Update is called once per frame
    void Update () {
        float input = Input.GetAxisRaw("Fire1");


        if (curr_weapon != weapon_to_use)
        {
            WeaponIndicator.once = false;
        }
        curr_weapon = weapon_to_use;

        // if (input > 0)
        if ((Input.GetKeyDown("space") && (!Movement.isDead && !gameController.isPaused)) || fire_weapon)
        {
            if (weapon_to_use == 0 && gameObject.tag == "turret")
            {
                Instantiate(weapon[weapon_to_use], transform.position, transform.rotation);
            }
            else if (weapon_to_use == 1 && gameObject.tag == "sniperTurret")
            {
                Instantiate(weapon[weapon_to_use], transform.position, transform.rotation);
            }

            fire_weapon = false;
        }
	}


    public void FireWeapon()
    {
        fire_weapon = true;
    }
}
