using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    float bullet_speed = 20f;
    Vector2 tmpPos;
	
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
