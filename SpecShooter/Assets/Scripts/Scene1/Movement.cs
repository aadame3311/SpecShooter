using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // movement for UI
    private bool left;
    private bool right;



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
        left = false;
        right = false;

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

        if (right)
        {
            transform.Rotate(0, 0, -1 * Time.deltaTime * turn_speed);

        }
        else if (left)
        {
            transform.Rotate(0, 0, 1 * Time.deltaTime * turn_speed);

        }
        // transform.Rotate(0, 0, -1 * Time.deltaTime * turn_speed);
    }

    public void LookRight()
    {
        Debug.Log(transform.rotation);
        right = true;
        left = false;


    }
    public void LookLeft()
    {

        right = false;
        left = true;
    }
    public void OnRelease()
    {
        right = false;
        left = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            turn_speed = 0.0f;

            isDead = true;


            anim.SetBool("isDead", true);
            Destroy(gameObject, 1.0f);

        }
    }
}
