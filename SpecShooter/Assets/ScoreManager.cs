using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreTxt;
	
	// Update is called once per frame
	void Update () {
        scoreTxt.text = "Score: " + SpawnerController.amount_killed;
	}
}
