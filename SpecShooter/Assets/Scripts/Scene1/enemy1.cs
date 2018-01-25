using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour {

    bool once = false;


    // spawner script. 
    public GameObject s;
    public SpawnerController sc;

    // self explanatory...
    private float health;

    // speed at which object moves.
    private float def_speed;
    private float speed;

    private Animator anim;

    private float div;

    // Use this for initialization
    void Start () {
        // initialize
        health = 4.0f;
        def_speed = 5.0f;
       
        //--calculate speed of enemies based on difficulty--//
        if (SpawnerController.difficulty > 3) div = 3.5f;
        else div = 3.0f;
        speed = (def_speed * SpawnerController.difficulty) / div;
        //--------------------------------------------------//


        // grab components.
        anim = gameObject.GetComponent<Animator>();

        // Makes sure only one instance of the object gets recorded for the SpawnerController script
        once = false;
    }

    private void FixedUpdate()
    {

        if (health <= 0)
        {
            if (!once)
            {
                // decrease the amount of enemies currently spawned on screen.
                once = true;
                SpawnerController.curr_spawned--;
                SpawnerController.amount_killed+=2;
            }

            anim.SetBool("isDead", true);
            Destroy(gameObject, 0.7f);

        }
        else
        {
            // move while object still has health
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
