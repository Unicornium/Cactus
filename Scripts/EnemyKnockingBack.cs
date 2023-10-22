﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockingBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnTriggerEnter2D(Collider2D other){ 

		if (other.gameObject.tag == "Player") {

			//knock back.
			var player = other.GetComponent<CactusController> ();
			player.knockbackCount = player.knockbackLength;

			if (other.transform.position.x < transform.position.x)
				player.knockFromRight = true;
			else
				player.knockFromRight = false;
		}
	}
}

