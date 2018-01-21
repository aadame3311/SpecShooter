using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // determine if player is dead. 
    public static bool isDead;

    // turn speed for player.
    private float turn_speed;

    // grabs rigid body component from player.
    private Rigidbody2D rb;

    // animation controller. 
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        isDead = false;
        turn_speed = 300f;

        // import animator controller.
        anim = GetComponent<Animator>();

        // import rigid body in order to be able to manipulate it.
        rb = GetComponent<Rigidbody2D>();
	}


    private void FixedUpdate()
    {

        if (SpawnerController.difficulty == 2)
            turn_speed = 350;
        else if (SpawnerController.difficulty == 3)
            turn_speed = 400;
        else if (SpawnerController.difficulty == 4)
            turn_speed = 450;


        // rotate player when left or right is pressed. 
        float sides = Input.GetAxisRaw("Horizontal");
        float move = Input.GetAxisRaw("Vertical");


        // rotation movement.
        if (sides != 0)
        {
            if (sides < 0)
            {
                // rotate right. 
                transform.Rotate(0, 0, -sides * Time.deltaTime * turn_speed);
            }
            else
            {
                // rotate left.
                transform.Rotate(0, 0, -sides * Time.deltaTime * turn_speed);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isDead = true;

            anim.SetBool("isDead", true);
            Destroy(gameObject, 1.0f);

        }
    }
}
