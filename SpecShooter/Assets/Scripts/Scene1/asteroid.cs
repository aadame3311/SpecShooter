using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour {

    //makes sure only 1 is substracted from 'curr spawned'
    //otherwise it would decrease 1 more than once since it does it every frame.
    bool once;


    //spawner script/gameobject.
    public GameObject s;
    public SpawnerController sc;

    private float turn_speed = 40f;
    private float health = 10f;

    private GameObject player;
    private float def_speed = 2.0f;
    private float speed = 2.0f;

    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        speed = (def_speed * SpawnerController.difficulty) / 2;

        // find player
        player = GameObject.FindGameObjectWithTag("Player");

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
        if (collision.gameObject.tag == "Player")
            speed = 0;
    }
}
