using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    float bullet_speed;

    private void Start()
    {
        if (gameObject.tag == "sniper")
            bullet_speed = 40f;
        else if (gameObject.tag == "PlayerLaser")
            bullet_speed = 20f;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position += transform.up * Time.deltaTime * bullet_speed;

        // regular bullets should only stay alive for no longer than 1.5 seconds.
        Destroy(gameObject, 1.5f);
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
