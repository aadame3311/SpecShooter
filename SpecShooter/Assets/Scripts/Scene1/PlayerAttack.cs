using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {


    public GameObject obj;

    // Update is called once per frame
    void Update () {
        float input = Input.GetAxisRaw("Fire1");

        // if (input > 0)
        if (Input.GetKeyDown("space") && (!Movement.isDead && !gameController.isPaused))
        {
            Instantiate(obj, transform.position, transform.rotation);
        }
	}
}
