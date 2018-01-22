using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour {

    //makes sure only 1 is substracted from 'curr spawned'
    //otherwise it would decrease 1 more than once since it does it every frame.
    bool once;

    // turn speed is used to simulate an asteroids natural movement in a vacum
    private float turn_speed = 40f;
    private float health = 10f;

    // speed at which the asteroid moves towards the origin. 
    // def_speed is used by the equation that calculates the speed as difficulty rises. 
    // this way, the def_speed always stays the same and we can base faster speeds on that.
    private float def_speed = 2.0f;
    private float speed = 2.0f;

    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        speed = (def_speed * SpawnerController.difficulty) / 2.5f;


        anim = gameObject.GetComponent<Animator>();


        //---//
        once = false;
	}
	
    // movement is done on fixed update, which means its independent of frames per second.
    void FixedUpdate()
    {

        if (health <= 0)
        {
            // decrease the amount of enemies currently spawned on screen.
            if (!once)
            {
                once = true;
                SpawnerController.curr_spawned--;
                SpawnerController.amount_killed++;

                // determine randomly which weapon to drop
                // it should be more likely to NOT drop anything at all. 
                PlayerAttack.weapon_to_use = (int)(Random.value * 2);

            }

            anim.SetBool("Explosion", true);
            Destroy(gameObject, 0.3f);

        }
        else
        {
            transform.Rotate(0, 0, Time.deltaTime * turn_speed);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, transform.position.z), speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerLaser")
            health--;
        if (collision.gameObject.tag == "sniper")
            health -= 5;
        if (collision.gameObject.tag == "Player")
            speed = 0;
    }
}
