﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
	}
}
